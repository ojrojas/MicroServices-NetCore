import { NgModule } from "@angular/core";
import { MedicosListarComponent } from "./medico-listar.component";
import { MedicosCrearComponent } from "./medico-crear.component";
import { MedicoEditarComponent } from "./medico-editar.component";
import { MedicoEliminarComponent } from "./medico-eliminar.component";
import { MedicoService } from "./medico.service";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MedicosRoutingModule } from "./medicos-routing.module";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
    declarations:[
        MedicosListarComponent,
        MedicosCrearComponent,
        MedicoEditarComponent,
        MedicoEliminarComponent,
    ],
    imports:[
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MedicosRoutingModule,
        HttpClientModule
    ],
    exports:[],
    providers:[
        MedicoService
    ]
    
})

export class MedicoModule {}