import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PacientesListarComponent } from "./paciente-listar.component";
import { PacientesCrearComponent } from "./paciente-crear.component";
import { PacienteEditarComponent } from "./paciente-editar.component";
import { PacienteEliminarComponent } from "./paciente-eliminar.component";

const routes: Routes = [
    { path: '', component: PacientesListarComponent },
    { path: 'paciente-crear', component: PacientesCrearComponent },
    { path: 'paciente-editar', component: PacienteEditarComponent },
    { path: 'paciente-eliminar', component: PacienteEliminarComponent }
  ];


@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})

export class PacientesRoutingModule{}