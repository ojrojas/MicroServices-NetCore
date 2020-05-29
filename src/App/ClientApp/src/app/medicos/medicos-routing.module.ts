import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { MedicosListarComponent } from "./medico-listar.component";
import { MedicosCrearComponent } from "./medico-crear.component";
import { MedicoEditarComponent } from "./medico-editar.component";
import { MedicoEliminarComponent } from "./medico-eliminar.component";

const routes: Routes = [
    { path: '', component: MedicosListarComponent },
    { path: 'medico-crear', component: MedicosCrearComponent },
    { path: 'medico-editar', component: MedicoEditarComponent },
    { path: 'medico-eliminar', component: MedicoEliminarComponent },
  ];


@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})

export class MedicosRoutingModule{}