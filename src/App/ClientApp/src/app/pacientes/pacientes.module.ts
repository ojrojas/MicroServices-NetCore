import { NgModule } from "@angular/core";
import { PacientesListarComponent } from "./paciente-listar.component";
import { PacientesCrearComponent } from "./paciente-crear.component";
import { PacienteEliminarComponent } from "./paciente-eliminar.component";
import { PacienteEditarComponent } from "./paciente-editar.component";
import { PacienteService } from "./paciente.service";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { PacientesRoutingModule } from "./pacientes-routing.module";
import { HttpClientModule } from "@angular/common/http";
import { MedicoService } from "../medicos/medico.service";

@NgModule({
    declarations:[
        PacientesListarComponent,
        PacientesCrearComponent,
        PacienteEliminarComponent,
        PacienteEditarComponent
    ],
    imports:[
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        PacientesRoutingModule,
        HttpClientModule
    ],
    providers:[
        PacienteService,
        MedicoService
    ],
    exports:[]
})

export class PacientesModule {}