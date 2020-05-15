import { Component } from "@angular/core";
import { Paciente } from "./paciente.model";
import {PacienteService} from './paciente.service';

@Component({
    selector:'app-editar-Paciente',
    templateUrl :'paciente-editar.component.html'
})

export class PacienteEditarComponent
{
    public model =  new Paciente();
    constructor(private PacienteService: PacienteService){}

    ngOnInit(){
        this.PacienteService.ObtenerPacienteId(window.localStorage.getItem("PacienteIdEditar"))
        .subscribe((val:Paciente) => {
            this.model = val;
        },error => {console.log(`No se obtuvo respuesta`)},
        ()=> {
            console.log("consulta finalizada PacienteId",this.model);
        });
    }

    onSubmit(form){
        if(form.valid)
        {
            this.PacienteService.ActualizarPacientes(form.value,this.model.id).subscribe(response => {
                console.log(response);
                form.reset();
            }, error => console.error(error),
            () => console.log("completado la accion de crear"));
        }
    }
}