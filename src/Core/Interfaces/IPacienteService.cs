using System.Collections.Generic;
using System.Threading.Tasks;
using Nexos.Core.Entidades;

namespace Nexos.Core.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> ObtenerPacienteIdAsync(string Id);
        Task<IReadOnlyList<Paciente>> ObtenerListaPacientesAsync();
        Task<IReadOnlyList<Paciente>> ObtenerPacienteEspecificaAsync(IEspecificacion<Paciente> especificacion);
        Task<Paciente> CrearPacienteAsync(Paciente paciente);
        Task<Paciente> ActualizarPacienteAsync(Paciente paciente, string Id);
        Task<Paciente> EliminarPacienteAsync(Paciente paciente, string Id);
        Task<int> ContarPacienteAsync(IEspecificacion<Paciente> especificacion);
    }
}