import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { AfterContentInit, Component, ElementRef, EventEmitter, OnDestroy, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CamundaPropertiesProvider, ElementTemplates, InjectionNames, Modeler, OriginalPaletteProvider, PropertiesPanelModule } from "@bol/bpmn-js/bpmn-js";
import { ProcessDefinitionDeployment } from '@models/pd-deployment';
import { CamundaService } from '@services/camunda.service';
import { ProgressBarService } from '@services/progressbar.service';
import * as BpmnJS from 'bpmn-js/dist/bpmn-modeler.production.min.js';
import * as CamundaModdleDescriptor from "camunda-bpmn-moddle/resources/camunda.json";
import notify from 'devextreme/ui/notify';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-camunda-modeler',
  templateUrl: './camunda-modeler.component.html',
  styleUrls: ['./camunda-modeler.component.scss']
})

export class CamundaModelerComponent implements AfterContentInit, OnDestroy, OnInit {
  title = 'Angular/BPMN';
  // instantiate BpmnJS with component
  private modeler: BpmnJS;
  private selectedProcessId: string;
  private diagramXml: string;
  private selectedProcessDiagram: string;
  public deployButtonText: string = "DEPLOY";

  // retrieve DOM element reference
  @ViewChild('ref', { static: true }) private el: ElementRef;
  @ViewChild('properties', { static: true }) private properties: ElementRef;
  @Output() private importDone: EventEmitter<any> = new EventEmitter();

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private progressbarService: ProgressBarService,
    private camundaService: CamundaService,
    private location: Location) {

    this.modeler = new Modeler({
      keyboard: {
        bindTo: document
      },
      additionalModules: [
        PropertiesPanelModule,
        { [InjectionNames.elementTemplates]: ['type', ElementTemplates.elementTemplates[1]] },
        // Re-use original bpmn-properties-module, see CustomPropsProvider
        { [InjectionNames.propertiesProvider]: ['type', CamundaPropertiesProvider.propertiesProvider[1]] },
        // Re-use original palette, see CustomPaletteProvider
        { [InjectionNames.originalPaletteProvider]: ['type', OriginalPaletteProvider] }
      ],
      // make camunda prefix known for import, editing and export
      moddleExtensions: {
        camunda: CamundaModdleDescriptor
      }

    });

    this.route.queryParams.subscribe(params => {
      this.selectedProcessId = params["selectedProcessId"];
      this.selectedProcessDiagram = params["selectedProcessDiagram"];
    });

    this.modeler.on('import.done', ({ error }) => {
      if (!error) {
        this.modeler.get('canvas').zoom('fit-viewport');
      }
    });
  }

  async ngOnInit(): Promise<void> {
    // Load selected bpmn
    if (this.selectedProcessId) {
      // Send the id to the component get the diagram
      this.camundaService.getProcessDefinitionDiagram(this.selectedProcessId).subscribe(
        async (result) => {
          if (result) {
            await this.loadDiagram(result.bpmn20Xml, false);
            console.log(result);
          }
        },
        err => {
          this.progressbarService.hide();
        }
      );
    } else if (this.selectedProcessDiagram) {
      await this.loadDiagram(this.selectedProcessDiagram, true);
    }
    else {
      this.deployButtonText = "DEPLOY";
      // Create new diagram
      this.createNewDiagram();
    }
  }

  private async loadDiagram(diagramXml: string, openedFile: boolean) {
    this.diagramXml = diagramXml;
    await this.modeler.importXML(this.diagramXml);
    if (openedFile)
      this.deployButtonText = "DEPLOY";
    else
      this.deployButtonText = "UPDATE";
  }

  ngAfterContentInit(): void {
    // attach BpmnJS instance to DOM element
    this.modeler.attachTo(this.el.nativeElement);

    // attach it to some other element
    var propertiesPanel = this.modeler.get('propertiesPanel');
    propertiesPanel.attachTo(this.properties.nativeElement);
  }

  ngOnDestroy(): void {
    // destroy BpmnJS instance
    this.modeler.destroy();
  }

  onBackClicked() {
    this.location.back();
  }

  onInitiateClicked() {

  }

  async onDeployedClicked() {
    let processDeployment: ProcessDefinitionDeployment = new ProcessDefinitionDeployment();
    processDeployment.duplicateFiltering = true;

    // Save diagram
    const result = await this.modeler.saveXML();
    let registry = this.modeler.get('elementRegistry');
    let allElements = registry.getAll();
    let root = allElements[0].id;

    processDeployment.name = root;
    processDeployment.bpmn20Xml = result.xml;
    await this.camundaService.createProcessDefinition(processDeployment).subscribe(
      async (result) => {
        notify("Process definition was successfuly deployed", "success", 600);
        console.log(result);
      });
  }

  /**
   * Load diagram from URL and emit completion event
   */
  loadUrl(url: string) {

    return (
      this.http.get(url, { responseType: 'text' }).pipe(
        catchError(err => throwError(err))
      ).subscribe(
        async (xml) => {
          await this.modeler.importXML(xml);
        }
      )
    );
  }

  handleError(err: any) {
    if (err) {
      console.warn('Ups, error: ', err);
    }
  }

  async saveBpmn() {
    try {
      const result = await this.modeler.saveXML();

      let registry = this.modeler.get('elementRegistry');

      const xml = result.xml;
      console.log(xml);
      return xml;
    } catch (err) {
      console.log(err);
      return "";
    }
  }

  async createNewDiagram() {
    try {
      const result = await this.modeler.createDiagram();
      const { warnings } = result;
      console.log(warnings);
    } catch (err) {
      console.log(err.message, err.warnings);
    }
  }

  openMiniMap() {
    this.modeler.get('minimap').open();
  }
}
