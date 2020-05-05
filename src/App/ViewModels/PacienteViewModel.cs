using System.Collections.Generic;
using Nexos.Core.Entidades;

namespace App.ViewModels
{
    public class PacienteViewModel
    {
        public string Id { get; set; } 
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NumeroSeguroSocial { get; set; }
        public Medico Medico { get; set; }
        public string MedicoId { get; set; }

        public Paciente ConvertirPacienteViewModelToPaciente(PacienteViewModel pacienteViewModel)
        {
            return new Paciente(
                pacienteViewModel.Id,
                pacienteViewModel.Nombre,
                pacienteViewModel.Apellido,
                pacienteViewModel.SegundoNombre,
                pacienteViewModel.SegundoApellido,
                pacienteViewModel.NumeroSeguroSocial,
                pacienteViewModel.Medico
            );
        }

         public IReadOnlyList<PacienteViewModel> ConvertirListaMedicoToListaMedicoViewModel(
            IReadOnlyList<Paciente> listaPacientes)
        {
            IReadOnlyList<PacienteViewModel> lista;
            List<PacienteViewModel> listaEnviar = new List<PacienteViewModel>();
            
            foreach(var i in listaPacientes)
            {
                listaEnviar.Add(new PacienteViewModel{
                    Id=i.Id,
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    SegundoNombre = i.SegundoNombre,
                    SegundoApellido = i.SegundoApellido,
                    NumeroSeguroSocial = i.NumeroSeguroSocial,
                    Medico = i.Medico,
                    MedicoId = i.MedicoId
                });
            }

            lista = listaEnviar;
            return lista;
        }
    }
}