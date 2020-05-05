using System.Collections.Generic;
using System.Threading.Tasks;
using App.ViewModels;
using Nexos.Core.Entidades;
using Nexos.Core.Interfaces;

namespace App.Servicios
{
    public interface IMedicoViewModelService
    {
        Task<IReadOnlyList<MedicoViewModel>> ObtenerMedicos();
        Task<MedicoViewModel> GuardarMedico(MedicoViewModel medico);
        Task<MedicoViewModel> ObtenerMedicoId(string Id);
        Task<IReadOnlyList<MedicoViewModel>> ObtenerMedicoEspecificacion(IEspecificacion<Medico> espeficicacion);
        Task<MedicoViewModel> ActualizarMedico(MedicoViewModel medico, string Id);
        Task<MedicoViewModel> EliminarMedico(MedicoViewModel medico, string Id);
        Task<int> ContarMedicos(IEspecificacion<Medico> especificacion);
    }
}