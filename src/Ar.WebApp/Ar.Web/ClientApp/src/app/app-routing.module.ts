import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('./features/processes/processes.module').then(m => m.ProcessesModule)  },
  { path: 'history', loadChildren: () => import('./features/processes/processes.module').then(m => m.ProcessesModule)  },
  { path: 'modeler', loadChildren: () => import('./features/modeler/modeler.module').then(m => m.ModelerModule)  }
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

