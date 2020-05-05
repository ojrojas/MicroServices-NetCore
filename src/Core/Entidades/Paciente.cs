using System;
using Nexos.Core.Interfaces;

namespace Nexos.Core.Entidades
{
    public class Paciente : BaseEntity, IAggregateRoot
    {
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public string MedicoId { get; set; }
        public Medico Medico { get; set; }

        public string NumeroSeguroSocial { get; set; }


        public void ActualizarDatosPaciente(Paciente paciente)
        {
            Nombre = paciente.Nombre ?? Nombre;
            SegundoNombre = paciente.SegundoNombre ?? SegundoNombre;
            Apellido = paciente.Apellido ?? Apellido;
            SegundoApellido = paciente.SegundoApellido ?? SegundoApellido;
            MedicoId = paciente.MedicoId ?? MedicoId;
            Medico = paciente.Medico ?? Medico;
            NumeroSeguroSocial = paciente.NumeroSeguroSocial ?? NumeroSeguroSocial;
        }

         public Paciente(
             string id,
             string nombre, 
             string apellido, 
             string segundoNombre, 
             string segundoApellido, 
             string nrosegurosocial,
             Medico medico)
        {
            Id = CrearNewGuid(id);
            Nombre = nombre;
            Apellido = apellido;
            SegundoNombre = segundoNombre;
            SegundoApellido = segundoApellido;
            NumeroSeguroSocial = nrosegurosocial;
            Medico = medico;
            MedicoId = medico.Id;
        }

        public Paciente(){}

        private string CrearNewGuid(string Id)
        {
            if(string.IsNullOrEmpty(Id)) return Guid.NewGuid().ToString();
            else return Id;           
        }
    }
}