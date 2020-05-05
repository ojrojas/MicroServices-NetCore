export class Medico {
   public id:string;
   public nombre: string;
   public apellido: number;
   public especialidad: string;

    constructor(obj?: any) {
        this.nombre = obj && obj.nombre || null;
        this.apellido = obj && obj.apellido;
        this.especialidad = obj && obj.especialidad || null;
        this.id = obj && obj.id || null;
    }

}