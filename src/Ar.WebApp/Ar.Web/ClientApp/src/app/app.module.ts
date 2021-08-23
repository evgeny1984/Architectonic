import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { ProgressBarComponent } from './components/progressbar/progressbar.component';
import { DevExtremeModule } from './modules/devextreme.module';
import { ProgressBarService } from './services/progressbar.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ProgressBarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    DevExtremeModule
  ],
  providers: [
    ProgressBarService
  ],
  exports: [RouterModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
