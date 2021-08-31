import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DevExtremeModule } from '@modules/devextreme.module';
import { AlertModule } from 'ngx-bootstrap/alert';
import { MonacoEditorModule } from 'ngx-monaco-editor';
import { AdlEditorRoutingModule } from './adl-editor-routing.module';
import { AdlEditorComponent } from './components/adl-editor/adl-editor.component';
import { AdlEditorService } from './services/adl-editor.service';

@NgModule({
  imports: [
    AlertModule.forRoot(),
    FormsModule,
    CommonModule,
    RouterModule,
    DevExtremeModule,
    AdlEditorRoutingModule,
    MonacoEditorModule.forRoot()
  ],
  exports: [
  ],
  providers: [
    AdlEditorService
  ],
  declarations: [
    AdlEditorComponent
  ]
})
export class AdlEditorModule {
}
