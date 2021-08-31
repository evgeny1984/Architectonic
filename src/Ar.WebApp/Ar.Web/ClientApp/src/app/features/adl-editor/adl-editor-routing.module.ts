import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdlEditorComponent } from './components/adl-editor/adl-editor.component';

const routes: Routes = [
    {
      path: '',
      component: AdlEditorComponent,
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
export class AdlEditorRoutingModule {
}
