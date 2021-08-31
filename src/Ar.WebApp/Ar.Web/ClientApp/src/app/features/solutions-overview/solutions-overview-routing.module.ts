import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SolutionsOverviewComponent } from './components/solutions-overview/solutions-overview.component';

const routes: Routes = [
    {
      path: '',
      component: SolutionsOverviewComponent,
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
export class SolutionsOverviewRoutingModule {
}
