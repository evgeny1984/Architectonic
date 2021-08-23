import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AlertModule } from 'ngx-bootstrap/alert';
import { DevExtremeModule } from '@modules/devextreme.module';
import { CamundaService } from '@services/camunda.service';
import { ProcessDefinitionsOverviewComponent } from './components/process-definitions-overview/process-definitions-overview.component';
import { ProcessInstanceHistoryComponent } from './components/process-instance-history/process-instance-history.component';
import { DeployProcessDefinitionComponent } from './dialogs/deploy-process-definition/deploy-process-definition.component';
import { SendCamundaMessageComponent } from './dialogs/send-camunda-message/send-camunda-message.component';
import { ProcessesRoutingModule } from './processes-routing.module';
import { ProcessInstanceStatePipe } from '@app/features/processes/pipes/process-instance-state.pipe';

@NgModule({
  imports: [
    AlertModule.forRoot(),
    FormsModule,
    CommonModule,
    RouterModule,
    DevExtremeModule,
    ProcessesRoutingModule
  ],
  exports: [
    
  ],
  providers: [
    CamundaService,
    ProcessInstanceStatePipe
  ],
  declarations: [
    ProcessDefinitionsOverviewComponent,
    SendCamundaMessageComponent,
    ProcessInstanceHistoryComponent,
    DeployProcessDefinitionComponent,
    ProcessInstanceStatePipe
  ]
})
export class ProcessesModule {
}
