import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProcessDefinitionsOverviewComponent } from './components/process-definitions-overview/process-definitions-overview.component';
import { ProcessInstanceHistoryComponent } from './components/process-instance-history/process-instance-history.component';

const routes: Routes = [
  {
    path: '',
    component: ProcessDefinitionsOverviewComponent,
  },
  {
    path: 'history',
    component: ProcessInstanceHistoryComponent,
  }
];

@NgModule({
  imports: [
    [RouterModule.forChild(routes)],
  ],
  exports: [
    [RouterModule]
  ],
})
export class ProcessesRoutingModule {
}
