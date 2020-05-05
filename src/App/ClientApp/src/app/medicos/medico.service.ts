


import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, of, throwError } from "rxjs";
import { tap, map } from 'rxjs/operators'
import { Medico } from "./medico.model";

const headers = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable()
export class MedicoService {
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    ObtenerMedicos(): Observable<Medico[]> {
        const queryObtenerMedicos = `${this.baseUrl}medicos/obtenermedicos`;
        console.log("servicio: ", queryObtenerMedicos);
        return this.http.get<Array<Medico>>(queryObtenerMedicos).pipe(
            tap(response => {
                return <Array<Medico>>response.map(item => {
                    return new Medico({
                        Nombre: item.nombre,
                        Apellido: item.apellido,
                        Especialidad: item.especialidad
                    });
                });
            }));
    }


    ObtenerMedicoId(id: string): Observable<Medico> {
        const queryObtenerMedicos = `${this.baseUrl}medicos/obtenermedicoid/id/${id}`;
        console.log("servicio: ", queryObtenerMedicos);
        return this.http.get<Medico>(queryObtenerMedicos).pipe(
            tap(response => {
                return response
            }));
    }

    CrearMedico(medico:Medico): Observable<Medico> {
        const queryCrearMedicos =`${this.baseUrl}medicos/crearmedicos`;
        return this.http.post<Medico>(queryCrearMedicos, medico,headers);
    }

    ActualizarMedicos(medico:Medico,id:string):Observable<Medico>
    {
        const queryEditarMedicos = `${this.baseUrl}medicos/ActualizarMedicos?id=${id}`;
        console.log("url editar medicos",queryEditarMedicos)
        return this.http.post<Medico>(queryEditarMedicos, medico,headers);
    }

    EliminarMedicos(medico:Medico, id:string): Observable<Medico>
    {
        const queryEditarMedicos = `${this.baseUrl}medicos/EliminarMedicos?id=${id}`;
        console.log("url eliminar medicos",queryEditarMedicos)
        return this.http.post<Medico>(queryEditarMedicos, medico,headers);
    }
}