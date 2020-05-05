using System.Collections.Generic;
using System.Threading.Tasks;
using App.ViewModels;
using Nexos.Core.Entidades;
using Nexos.Core.Interfaces;

namespace App.Servicios
{
    public interface IPacienteViewModelService
    {
        Task<IReadOnlyList<PacienteViewModel>> ObtenerPacientes();
        Task<PacienteViewModel> GuardarPaciente(PacienteViewModel paciente);
        Task<PacienteViewModel> ObtenerPacienteId(string Id);
        Task<IReadOnlyList<PacienteViewModel>> ObtenerPacienteEspecificacion(IEspecificacion<Paciente> espeficicacion);
        Task<PacienteViewModel> ActualizarPaciente(PacienteViewModel paciente, string Id);
        Task<PacienteViewModel> EliminarPaciente(PacienteViewModel paciente, string Id);
        Task<int> ContarPacientes(IEspecificacion<Paciente> espeficicacion);
    }
}