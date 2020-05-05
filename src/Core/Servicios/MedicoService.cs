using System.Collections.Generic;
using System.Threading.Tasks;
using Nexos.Core.Entidades;
using Nexos.Core.Interfaces;

namespace Nexos.Core.Servicios
{
    public class MedicoService : IMedicoService
    {
        private readonly IRepositoryAsync<Medico> _repositorioMedico;
        private readonly IAppLogger<MedicoService> _logger;

        public MedicoService(IRepositoryAsync<Medico> repositorioMedico, IAppLogger<MedicoService> logger)
        {
            _repositorioMedico = repositorioMedico;
            _logger = logger;
        }

        public async Task<Medico> ActualizarMedicosAsync(Medico medico, string Id)
        {
            if (_logger != null)
                _logger.LogInformacion($"Se esta aculizando el medico {medico.Nombre} {medico.Apellido}");
            var medico1 = await _repositorioMedico.ObtenerIdAsync(Id);
            medico1.ActualizarDatosMedico(medico);
            await _repositorioMedico.ActualizarAsync(medico1);
            _logger.LogInformacion($"Medico actualizado!!");
            return medico1;
        }

        public async Task<int> ContarMedicosAsync(IEspecificacion<Medico> especificacion)
        {
            var conteo = await _repositorioMedico.ConteoAsync(especificacion);
             if (_logger != null)
                _logger.LogInformacion($"Se contarón {conteo} Medicos");
                return conteo;
        }

        public async Task<Medico> CrearMedicoAsync(Medico medico)
        {
            if (_logger != null)
                _logger.LogInformacion($"Se crea el medico {medico.Nombre} {medico.Apellido}");
            await _repositorioMedico.CrearAsync(medico);
            if (_logger != null)
                _logger.LogInformacion($"medico creado con exito {medico.Nombre} {medico.Apellido}");
            return medico;
        }

        public async Task<Medico> ElimnarMedicoAsync(Medico medico, string Id)
        {
            if (_logger != null)
                _logger.LogInformacion($"Se eliminara el medico {medico.Nombre} {medico.Apellido}");
            var medicoEliminado = await _repositorioMedico.ObtenerIdAsync(Id);
            await _repositorioMedico.EliminarAsync(Id);
             if (_logger != null)
                _logger.LogInformacion($"Medico eliminado con exito {medico.Nombre} {medico.Apellido}");
                return medico;
        }

        public async Task<Medico> ObtenerMedicoPorIdAsync(string Id)
        {
            if (_logger != null)
                _logger.LogInformacion($"Obteniendo medico por Id {Id}.");
            return await _repositorioMedico.ObtenerIdAsync(Id);
        }

        public async Task<IReadOnlyList<Medico>> ObtenerMedicosAsync()
        {
             if (_logger != null)
                _logger.LogInformacion($"Obteniendo lista de medicos.");
            return await _repositorioMedico.ObtenerListaAsync();
        }

        public async Task<IReadOnlyList<Medico>> ObtenerMedicosEspecificosAsync(IEspecificacion<Medico> especificacion)
        {
            if (_logger != null)
                _logger.LogInformacion($"Obteniendo lista de medicos especifica. tipo especificacion {especificacion.ToString()}");
            return await _repositorioMedico.ObtenerListaEspecificaAsync(especificacion);
        }
    }
}