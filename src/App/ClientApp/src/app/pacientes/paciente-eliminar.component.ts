import { Component } from "@angular/core";
import { PacienteService } from "./paciente.service";
import { Paciente } from "./paciente.model";

@Component({
    selector: 'app-eliminar-Paciente',
    templateUrl: 'paciente-eliminar.component.html'
})

export class PacienteEliminarComponent {
    public model = new Paciente();
    constructor(private PacienteService: PacienteService) { }

    ngOnInit() {
        this.PacienteService.ObtenerPacienteId(window.localStorage.getItem("PacienteIdEliminar"))
            .subscribe((val: Paciente) => {
                this.model = val;
            }, error => { console.log(`No se obtuvo respuesta`) },
                () => {
                    console.log("consulta finalizada PacienteId", this.model);
                });
    }

    onSubmit(form) {
        if (form.valid) {
            this.PacienteService.EliminarPacientes(form.value, this.model.id).subscribe(response => {
                console.log(response);
                form.reset();
            }, error => console.error(error),
                () => console.log("completado la accion de crear"));
        }
    }
}