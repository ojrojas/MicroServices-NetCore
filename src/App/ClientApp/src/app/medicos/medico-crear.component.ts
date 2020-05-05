import { Component } from "@angular/core";
import { MedicoService } from "./medico.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Medico } from "./medico.model";
import { subscribeOn } from "rxjs/operators";

@Component({
    selector:'app-medicos-crear',
    templateUrl: 'medico-crear.component.html'
})

export class MedicosCrearComponent
{
    public model =  new Medico();
    constructor(private medicoService : MedicoService)
    {
       
    }

    onSubmit(form)
    {
        if(form.valid)
        {
            this.medicoService.CrearMedico(form.value).subscribe(response => {
                console.log(response);
                form.reset();
            }, error => console.error(error),
            () => console.log("completado la accion de crear"));
        }
    }
}