import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdlFile } from '@models/adl-file.model';
import { ProgressBarService } from '@services/progressbar.service';
import notify from 'devextreme/ui/notify';
import { AdlEditorService } from '../../services/adl-editor.service';

@Component({
  selector: 'app-adl-editor',
  templateUrl: './adl-editor.component.html',
  styleUrls: ['./adl-editor.component.scss']
})
export class AdlEditorComponent implements OnInit {
  public adlContent: string;
  public selectedSolutionId: number;
  public newSolutionButtonText: string = "CREATE PROJECT";
  public editorOptions = { theme: 'vs-dark', language: 'javascript' };

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private progressbarService: ProgressBarService,
    private location: Location,
    private adlEditorService: AdlEditorService) {

    this.route.queryParams.subscribe(params => {
      this.selectedSolutionId = params["selectedSolutionId"];
      this.adlContent = params["adlContent"];
    });

  }

  ngOnInit() {
    if (!this.selectedSolutionId) {
      this.newSolutionButtonText = "CREATE PROJECT";
    }
  }

  async onDeployedClicked() {
    let adlFile: AdlFile = new AdlFile();
    adlFile.body = this.adlContent;
    adlFile.createdAt = new Date();
    adlFile.name = `Solution ${this.selectedSolutionId ?? ""}`
    adlFile.description = "-"

    await this.adlEditorService.uploadAdlContent(adlFile).toPromise();
    notify("Solution was successfuly created", "success", 600);
  }

  onBackClicked() {
    this.location.back();
  }


}
