using System;
using Nexos.Core.Interfaces;

namespace Nexos.Core.Entidades
{
    public class Medico : BaseEntity,IAggregateRoot
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }

        public void ActualizarDatosMedico(Medico medico)
        {
            Nombre = medico.Nombre ?? Nombre;
            Apellido = medico.Apellido ?? Apellido;
            Especialidad = medico.Especialidad ?? Especialidad; 
        }

        public Medico(string id, string nombre, string apellido, string especialidad)
        {
            Id = CrearNewGuid(id);
            Nombre = nombre;
            Apellido = apellido;
            Especialidad = especialidad;
        }

        private string CrearNewGuid(string Id)
        {
            if(string.IsNullOrEmpty(Id)) return Guid.NewGuid().ToString();
            else return Id;           
        }

        public Medico() {}
    }
}