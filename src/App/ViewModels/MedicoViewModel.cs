using System.Collections.Generic;
using Nexos.Core.Entidades;

namespace App.ViewModels
{
    public class MedicoViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }

        public Medico ConvertirMedicoViewModelToMedico(MedicoViewModel medicoViewmodel)
        {
            return new Medico(medicoViewmodel.Id,
                medicoViewmodel.Nombre,
                medicoViewmodel.Apellido,
                medicoViewmodel.Especialidad);
        }

        public IReadOnlyList<MedicoViewModel> ConvertirListaMedicoToListaMedicoViewModel(
            IReadOnlyList<Medico> listaMedicos)
        {
            IReadOnlyList<MedicoViewModel> lista;
            List<MedicoViewModel> listaEnviar = new List<MedicoViewModel>();
            
            foreach(var i in listaMedicos)
            {
                listaEnviar.Add(new MedicoViewModel{
                    Id=i.Id,
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    Especialidad = i.Especialidad
                });
            }

            lista = listaEnviar;
            return lista;
        }

    


    }
}