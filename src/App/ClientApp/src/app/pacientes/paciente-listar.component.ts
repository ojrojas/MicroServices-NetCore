import { Component } from "@angular/core";
import { PacienteService } from "./paciente.service";
import { Paciente } from "./paciente.model";
import { Router } from "@angular/router";


@Component({
    selector: 'app-paciente-listar',
    templateUrl : 'paciente-listar.component.html'
})
export class PacientesListarComponent
{
    public pacientes:Paciente[];
    selectedPaciente:Paciente;

    constructor(private pacienteService: PacienteService, private router: Router)
    {

    }

    onSelect(paciente: Paciente) : void
    {
        this.selectedPaciente = paciente;
    }

    ngOnInit()
    {
        this.pacienteService.ObtenerPacientes()
        .subscribe((val:Paciente[]) => {
            this.pacientes = val;
        },error => {console.log(`No se obtuvo respuesta`)},
        ()=> {
            console.log("consulta finalizada",this.pacientes);
        });
    }

    EliminarPaciente(){
    window.localStorage.removeItem("PacienteIdEliminar");
    window.localStorage.setItem("PacienteIdEliminar", this.selectedPaciente.id);
    this.router.navigate(['pacientes/paciente-eliminar']);

    }

    EditarPaciente(){
        window.localStorage.removeItem("PacienteIdEditar");
        window.localStorage.setItem("PacienteIdEditar", this.selectedPaciente.id);
        this.router.navigate(['pacientes/paciente-editar']);
    }
}