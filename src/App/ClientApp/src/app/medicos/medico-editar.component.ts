import { Component } from "@angular/core";
import { MedicoService } from "./medico.service";
import { Medico } from "./medico.model";

@Component({
    selector:'app-editar-medico',
    templateUrl :'medico-editar.component.html'
})

export class MedicoEditarComponent
{
    public model =  new Medico();
    constructor(private medicoService: MedicoService)
    {

    }

    ngOnInit()
    {
        this.medicoService.ObtenerMedicoId(window.localStorage.getItem("medicoIdEditar"))
        .subscribe((val:Medico) => {
            this.model = val;
        },error => {console.log(`No se obtuvo respuesta`)},
        ()=> {
            console.log("consulta finalizada medicoId",this.model);
        });
    }

    onSubmit(form){
        if(form.valid)
        {
            this.medicoService.ActualizarMedicos(form.value,this.model.id).subscribe(response => {
                console.log(response);
                form.reset();
            }, error => console.error(error),
            () => console.log("completado la accion de crear"));
        }
    }
}