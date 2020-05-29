import { Component } from "@angular/core";
import { MedicoService } from "./medico.service";
import { Medico } from "./medico.model";
import { Router } from "@angular/router";


@Component({
    selector: 'app-medico-listar',
    templateUrl : 'medico-listar.component.html'
})
export class MedicosListarComponent
{
    public medicos:Medico[];
    selectedMedico:Medico;

    constructor(private medicoService: MedicoService, private router: Router)
    {

    }

    onSelect(medico: Medico) : void
    {
        this.selectedMedico = medico;
    }

    ngOnInit()
    {
        this.medicoService.ObtenerMedicos()
        .subscribe((val:Medico[]) => {
            this.medicos = val;
        },error => {console.log(`No se obtuvo respuesta`)},
        ()=> {
            console.log("consulta finalizada",this.medicos);
        });
    }

    EliminarMedico(){
    window.localStorage.removeItem("medicoIdEliminar");
    window.localStorage.setItem("medicoIdEliminar", this.selectedMedico.id);
    this.router.navigate(['medicos/medico-eliminar']);

    }

    EditarMedico(){
        window.localStorage.removeItem("medicoIdEditar");
        window.localStorage.setItem("medicoIdEditar", this.selectedMedico.id);
        this.router.navigate(['medicos/medico-editar']);
    }
}