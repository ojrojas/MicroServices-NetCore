import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MedicosListarComponent } from './medicos/medico-listar.component';
import { MedicoService } from './medicos/medico.service';
import { MedicosCrearComponent } from './medicos/medico-crear.component';
import { MedicoEditarComponent } from './medicos/medico-editar.component';
import { MedicoEliminarComponent } from './medicos/medico-eliminar.component';
import { PacientesListarComponent } from './pacientes/paciente-listar.component';
import { PacientesCrearComponent } from './pacientes/paciente-crear.component';
import { PacienteEditarComponent } from './pacientes/paciente-editar.component';
import { PacienteEliminarComponent } from './pacientes/paciente-eliminar.component';
import { PacienteService } from './pacientes/paciente.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MedicosListarComponent,
    MedicosCrearComponent,
    MedicoEditarComponent,
    MedicoEliminarComponent,
    PacientesListarComponent,
    PacientesCrearComponent,
    PacienteEliminarComponent,
    PacienteEditarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'medico-listar', component : MedicosListarComponent},
      { path: 'medico-crear', component: MedicosCrearComponent},
      { path: 'medico-editar', component : MedicoEditarComponent},
      { path: 'medico-eliminar', component : MedicoEliminarComponent},
      { path: 'paciente-listar', component : PacientesListarComponent},
      { path: 'paciente-crear', component: PacientesCrearComponent},
      { path: 'paciente-editar', component : PacienteEditarComponent},
      { path: 'paciente-eliminar', component : PacienteEliminarComponent}
    ])
  ],
  providers: [
    MedicoService,
    PacienteService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
