import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PacienteService } from './pacientes/paciente.service';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
   
    CommonModule,
    AppRoutingModule

  ],
  providers: [
    PacienteService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
