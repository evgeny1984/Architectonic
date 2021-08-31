import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DevExtremeModule } from '@modules/devextreme.module';
import { AlertModule } from 'ngx-bootstrap/alert';
import { MonacoEditorModule } from 'ngx-monaco-editor';
import { SolutionsOverviewComponent } from './components/solutions-overview/solutions-overview.component';
import { SolutionsOverviewService } from './services/solutions-overview.service';
import { SolutionsOverviewRoutingModule } from './solutions-overview-routing.module';

@NgModule({
  imports: [
    AlertModule.forRoot(),
    FormsModule,
    CommonModule,
    RouterModule,
    DevExtremeModule,
    SolutionsOverviewRoutingModule,
    MonacoEditorModule.forRoot()
  ],
  exports: [
  ],
  providers: [
    SolutionsOverviewService
  ],
  declarations: [
    SolutionsOverviewComponent
  ]
})
export class SolutionsOverviewModule {
}
