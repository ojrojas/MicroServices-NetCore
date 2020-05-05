import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, of, throwError } from "rxjs";
import { tap, map } from 'rxjs/operators'
import { Paciente } from "./paciente.model";

const headers = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable()
export class PacienteService {
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    ObtenerPacientes(): Observable<Paciente[]> {
        const queryObtenerPacientes = `${this.baseUrl}Pacientes/ObtenerPacientes`;
        console.log("servicio: ", queryObtenerPacientes);
        return this.http.get<Array<Paciente>>(queryObtenerPacientes).pipe(
            tap(response => {
                return <Array<Paciente>>response.map(item => {
                    return new Paciente({
                        Nombre: item.nombre,
                        Apellido: item.apellido,
                        SegundoApellido: item.segundoApellido,
                        SegundoNombre : item.segundoNombre,
                        NumeroSeguroSocial : item.numeroSeguroSocial,
                        Medico: item.medico,
                        MedicoId : item.medicoId
                    });
                });
            }));
    }


    ObtenerPacienteId(id: string): Observable<Paciente> {
        const queryObtenerPacientes = `${this.baseUrl}Pacientes/ObtenerPacienteId/Id/${id}`;
        console.log("servicio: ", queryObtenerPacientes);
        return this.http.get<Paciente>(queryObtenerPacientes).pipe(
            tap(response => {
                return response
            }));
    }

    CrearPaciente(paciente:Paciente): Observable<Paciente> {
        const queryCrearPacientes =`${this.baseUrl}Pacientes/CrearPacientes`;
        return this.http.post<Paciente>(queryCrearPacientes,paciente,headers);
    }

    ActualizarPacientes(paciente:Paciente,id:string):Observable<Paciente>
    {
        const queryEditarPacientes = `${this.baseUrl}Pacientes/ActualizarPacientes?id=${id}`;
        console.log("url editar Pacientes",queryEditarPacientes)
        return this.http.post<Paciente>(queryEditarPacientes, paciente,headers);
    }

    EliminarPacientes(paciente:Paciente, id:string): Observable<Paciente>
    {
        const queryEditarPacientes = `${this.baseUrl}Pacientes/EliminarPacientes?id=${id}`;
        console.log("url eliminar Pacientes",queryEditarPacientes)
        return this.http.post<Paciente>(queryEditarPacientes, paciente,headers);
    }
}