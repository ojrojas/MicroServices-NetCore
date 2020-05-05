import { Medico } from "../medicos/medico.model";

export class Paciente {
   public id:string;
   public nombre: string;
   public apellido: number;
   public segundoApellido: string;
   public segundoNombre: string;
   public numeroSeguroSocial: string;
   public medicoId: string;
   public medico : Medico;

    constructor(obj?: any) {
        this.nombre = obj && obj.nombre || null;
        this.apellido = obj && obj.apellido;
        this.segundoApellido = obj && obj.especialidad || null;
        this.id = obj && obj.id || null;
        this.segundoNombre = obj && obj.segundoNombre || null;
        this.numeroSeguroSocial = obj && obj.numeroSeguroSocial || null;
        this.medicoId = obj && obj.medicoId || null;
        this.medico = obj && obj.medico || null;
    }

}