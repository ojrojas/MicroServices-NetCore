using System.Collections.Generic;
using System.Threading.Tasks;
using Nexos.Core.Entidades;

namespace Nexos.Core.Interfaces
{
    public interface IMedicoService
    {
        Task<Medico> CrearMedicoAsync(Medico medico);
        Task<IReadOnlyList<Medico>> ObtenerMedicosAsync();
        Task<Medico> ObtenerMedicoPorIdAsync(string Id);
        Task<IReadOnlyList<Medico>> ObtenerMedicosEspecificosAsync(IEspecificacion<Medico> especificacion);
        Task<Medico> ActualizarMedicosAsync(Medico medico, string Id);
        Task<Medico> ElimnarMedicoAsync(Medico medico, string Id);
        Task<int> ContarMedicosAsync(IEspecificacion<Medico> especificacion);
    }
}