import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MessageBoxComponent } from '@components/messagebox/messagebox.component';
import { ProgressBarComponent } from '@components/progressbar/progressbar.component';
import { AlertModule } from 'ngx-bootstrap/alert';
import { DevExtremeModule } from './devextreme.module';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    AlertModule.forRoot(),
    DevExtremeModule
  ],
  exports: [
    MessageBoxComponent,
    ProgressBarComponent,
    DevExtremeModule
  ],
  declarations: [
    ProgressBarComponent,
    MessageBoxComponent
  ],
  providers: [
    
  ]
})
export class SharedModule {

}
