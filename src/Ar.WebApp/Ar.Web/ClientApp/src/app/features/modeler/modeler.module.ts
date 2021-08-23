import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AlertModule } from 'ngx-bootstrap/alert';
import { DevExtremeModule } from '@modules/devextreme.module';
import { CamundaService } from '@services/camunda.service';
import { CamundaModelerComponent } from './components/camunda-modeler/camunda-modeler.component';
import { ModelerRoutingModule } from './modeler-routing.module';

@NgModule({
  imports: [
    AlertModule.forRoot(),
    FormsModule,
    CommonModule,
    RouterModule,
    DevExtremeModule,
    ModelerRoutingModule
  ],
  exports: [
  ],
  providers: [
    CamundaService
  ],
  declarations: [
    CamundaModelerComponent
  ]
})
export class ModelerModule {
}
