import { Component } from "@angular/core";
import { MedicoService } from "./medico.service";
import { Medico } from "./medico.model";

@Component({
    selector:'app-eliminar-medico',
    templateUrl :'medico-eliminar.component.html'
})

export class MedicoEliminarComponent
{
    public model =  new Medico();
    constructor(private medicoService: MedicoService)
    {
    }

    ngOnInit()
    {
        this.medicoService.ObtenerMedicoId(window.localStorage.getItem("medicoIdEliminar"))
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
            this.medicoService.EliminarMedicos(form.value,this.model.id).subscribe(response => {
                console.log(response);
                form.reset();
            }, error => console.error(error),
            () => console.log("completado la accion de crear"));
        }
    }
}