import { ChangeDetectorRef, Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { DialogResult } from '@bol/dialog-result.enum';
import { ProcessDefinitionMessage } from '@models/pd-message.model';
import { ProcessDefinition } from '@models/process-definition.model';
import { CamundaService } from '@services/camunda.service';
import { ProgressBarService } from '@services/progressbar.service';
import { DxDataGridComponent } from 'devextreme-angular/ui/data-grid';
import dxButton from 'devextreme/ui/button';
import notify from 'devextreme/ui/notify';
import { ProcessDefinitionBpmn } from '@models/pd-bpmn';
import { saveAs } from 'file-saver';
import { SendCamundaMessageComponent } from '@features/processes/dialogs/send-camunda-message/send-camunda-message.component';

@Component({
  selector: 'app-process-definitions-overview',
  templateUrl: './process-definitions-overview.component.html',
  styleUrls: ['./process-definitions-overview.component.scss']
})
export class ProcessDefinitionsOverviewComponent implements OnInit {
  public processDefinitions: Array<ProcessDefinition>;
  public selectedProcessDefinition: ProcessDefinition;
  public gridHeight: number = 560;
  public messageEnabled: boolean = false;
  public downloadEnabled: boolean = false;
  public btnExportInstance: dxButton;
  public btnDownloadInstance: dxButton;
  @ViewChild('processDefinitionsGrid', { static: true }) dataGrid: DxDataGridComponent;
  @ViewChild(SendCamundaMessageComponent) private sendCamundaMessageDialog: SendCamundaMessageComponent;
  @ViewChild('fileInput', { static: true }) fileInput: ElementRef;

  constructor(
    private progressbarService: ProgressBarService,
    private camundaService: CamundaService,
    private cdr: ChangeDetectorRef,
    private router: Router) {
    this.processDefinitions = new Array<ProcessDefinition>();

    // Bind all callbacks
    this.messageSentCallback = this.messageSentCallback.bind(this);
  }

  ngOnInit(): void {
    this.loadProcessDefinitions();
  }

  ngAfterViewInit(): void {
    this.calculateGridHeight();
    this.cdr.detectChanges();
  }

  /**
 * Handle the resize event to set the grid height
 * @param $event The event args
 */
  @HostListener('window:resize', ['$event'])
  onResize(event?) {
    this.calculateGridHeight();
  }

  /**Calculate the data grid height dynamically based on the window height and element position */
  private calculateGridHeight(): void {
    this.gridHeight = window.innerHeight - this.dataGrid.instance.element().getBoundingClientRect().top - 5;
  }

  private loadProcessDefinitions() {
    this.progressbarService.show('Loading process definitions...');
    this.camundaService.getAllProcessDefinitions().subscribe(
      (result: ProcessDefinition[]) => {
        this.processDefinitions = result;
        this.progressbarService.hide();
      },
      err => {
        this.progressbarService.hide();
      }
    );
  }

  onToolbarPreparing(e) {
    let toolbarItems = e.toolbarOptions.items;

    // Add new items
    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "refresh",
        onClick: this.refreshProcesses.bind(this),
        hint: 'Refresh'
      },
      location: "after"
    });

    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "message",
        disabled: !this.messageEnabled,
        onClick: this.sendMessage.bind(this),
        hint: 'Send message',
        onInitialized: (args: any) => {
          this.btnExportInstance = args.component;
        },
      },
      location: "after"
    });

    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "plus",
        onClick: this.createNewProcess.bind(this),
        hint: 'New process'
      },
      location: "after"
    });

    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "folder",
        onClick: this.openExistingProcess.bind(this),
        hint: 'Existing process'
      },
      location: "after"
    });

    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "download",
        disabled: !this.downloadEnabled,
        onClick: this.downloadSelectedProcess.bind(this),
        hint: 'Download process',
        onInitialized: (args: any) => {
          this.btnDownloadInstance = args.component;
        },
      },
      location: "after"
    });

    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "trash",
        onClick: this.deleteSelectedProcess.bind(this),
        hint: 'Delete process'
      },
      location: "after"
    });
  }

  public createNewProcess() {
    // Navigate to the diagram page and create a new process diagram
    this.router.navigate(['/modeler']);
  }

  public openExistingProcess() {
    // Open dialog to select the diagram bpmn
    this.fileInput.nativeElement.click()
  }

  onFileSelected(event) {
    let file = event.target.files[0];

    let fileReader = new FileReader();
    fileReader.onload = (e) => {
      // Navigate to modeler to open new diagram
      if (fileReader.result) {
        let navigationExtras: NavigationExtras = {
          queryParams: {
            "selectedProcessDiagram": fileReader.result
          }
        };
        this.router.navigate(['/modeler'], navigationExtras);
      }
      console.log(fileReader.result);
    }
    fileReader.readAsText(file);
  }

  public deleteSelectedProcess() {
    if (this.selectedProcessDefinition) {
      this.camundaService.deleteProcessDefinition(this.selectedProcessDefinition.id).subscribe(
        (result: string) => {
          notify("Selected process definition was deleted.", "success", 600);
          this.loadProcessDefinitions();
        },
        error => {
          console.log(error);
        });

    }
  }

  public refreshProcesses() {
    this.loadProcessDefinitions();
  }

  public sendMessage() {
    this.sendCamundaMessageDialog.showDialog();
  }

  onSelectProcess(event) {
    if (event) {
      this.selectedProcessDefinition = event.data;
      this.messageEnabled = true;
      this.downloadEnabled = true;
      if (this.btnExportInstance) {
        this.btnExportInstance.option({
          disabled: false
        });
      }
      if (this.btnDownloadInstance) {
        this.btnDownloadInstance.option({
          disabled: false
        });
      }
    }
  }

  public openSelectedProcess(event) {
    if (event) {
      let selectedProcess: ProcessDefinition = event.data;
      if (selectedProcess) {
        let navigationExtras: NavigationExtras = {
          queryParams: {
            "selectedProcessId": selectedProcess.id
          }
        };
        this.router.navigate(['/modeler'], navigationExtras);
      }

    }
  }

  public async downloadSelectedProcess() {
    let result: ProcessDefinitionBpmn = null;

    if (this.selectedProcessDefinition) {
      // Send the id to the component get the diagram
      result = await this.camundaService.getProcessDefinitionDiagram(this.selectedProcessDefinition.id).toPromise();

      if (result) {
        const fileName = `${this.selectedProcessDefinition.key}.bpmn`;
        saveAs(new Blob([result.bpmn20Xml], { type: 'application/xml' }), fileName);
      }
    }
  }

  public messageSentCallback(result: DialogResult, message: ProcessDefinitionMessage) {

    if (result === DialogResult.OK && message) {
      // Send the message to camunda engine
      this.camundaService.sendCorrelationMessage(message).subscribe(
        (result) => {
          notify("Message was successfuly sent", "success", 600);
        });

    };

  }

}
