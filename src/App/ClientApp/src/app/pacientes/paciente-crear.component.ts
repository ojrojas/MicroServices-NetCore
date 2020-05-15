import { Component } from "@angular/core";
import { PacienteService } from "./paciente.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Paciente } from "./paciente.model";
import { subscribeOn } from "rxjs/operators";
import { Medico } from "../medicos/medico.model";
import { MedicoService } from "../medicos/medico.service";

@Component({
    selector:'app-pacientes-crear',
    templateUrl: 'paciente-crear.component.html'
})

export class PacientesCrearComponent
{
    public model =  new Paciente();
    medicos: Medico[];
    constructor(
        private pacienteService : PacienteService, 
        private medicoService: MedicoService){      
    }

    ngOnInit(){
        this.medicoService.ObtenerMedicos()
        .subscribe((val:Medico[]) => {
            this.medicos = val;
        },error => {console.log(`No se obtuvo respuesta`)},
        ()=> {
            console.log("consulta finalizada",this.medicos);
        });
    }

    onSubmit(form)
    {
        if(form.valid)
        {
            console.log(form.value);
            this.pacienteService.CrearPaciente(form.value).subscribe(response => {
                console.log(response);
                form.clear();
            }, error => console.error(error),
            () => console.log("completado la accion de crear"));
        }
    }
}