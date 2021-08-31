import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('./features/solutions-overview/solutions-overview.module').then(m => m.SolutionsOverviewModule) },
  { path: 'adl-editor', loadChildren: () => import('./features/adl-editor/adl-editor.module').then(m => m.AdlEditorModule) }
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      routes,
      {
        enableTracing: true,
        preloadingStrategy: PreloadAllModules
      }
    )
  ],
  exports: [RouterModule],
  providers: [
  ]
})
export class AppRoutingModule {
}

