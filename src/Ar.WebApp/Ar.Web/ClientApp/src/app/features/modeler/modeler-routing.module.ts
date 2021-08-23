import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CamundaModelerComponent } from './components/camunda-modeler/camunda-modeler.component';

const routes: Routes = [
    {
    path: '',
    component: CamundaModelerComponent,
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
export class ModelerRoutingModule {
}
