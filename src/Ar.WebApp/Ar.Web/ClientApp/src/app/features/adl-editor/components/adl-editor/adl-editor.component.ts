import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProgressBarService } from '../../../../services/progressbar.service';
import { AdlEditorService } from '../../services/adl-editor.service';

@Component({
  selector: 'app-adl-editor',
  templateUrl: './adl-editor.component.html',
  styleUrls: ['./adl-editor.component.scss']
})
export class AdlEditorComponent {
  public adlContent: string;
  public selectedSolutionId: number;
  public editorOptions = { theme: 'vs-dark', language: 'javascript' };

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private progressbarService: ProgressBarService,
    private adlEditorService: AdlEditorService) {

    this.route.queryParams.subscribe(params => {
      this.selectedSolutionId = params["selectedSolutionId"];
      this.adlContent = params["adlContent"];
    });

  }
}
