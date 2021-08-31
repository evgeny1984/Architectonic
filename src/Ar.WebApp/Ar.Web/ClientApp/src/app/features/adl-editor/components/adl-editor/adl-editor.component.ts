import { Component } from '@angular/core';

@Component({
  selector: 'app-adl-editor',
  templateUrl: './adl-editor.component.html',
  styleUrls: ['./adl-editor.component.scss']
})
export class AdlEditorComponent {
  public adlContent: string;
  public editorOptions = { theme: 'vs-dark', language: 'javascript' };

  constructor() {
    this.adlContent = "";
  }
}
