using System.Collections.Generic;
using System.Threading.Tasks;
using Nexos.Core.Entidades;
using Nexos.Core.Interfaces;

namespace Nexos.Core.Servicios
{
    public class PacienteService : IPacienteService
    {
        private readonly IRepositoryAsync<Paciente> _repositorioPaciente;
        private readonly IAppLogger<PacienteService> _logger;

        public PacienteService(IRepositoryAsync<Paciente> repositorioPaciente, IAppLogger<PacienteService> logger)
        {
            _repositorioPaciente = repositorioPaciente;
            _logger = logger;
        }

        public async Task<Paciente> ActualizarPacienteAsync(Paciente paciente, string Id)
        {
            if (_logger != null)
                _logger.LogInformacion($"Se esta aculizando el paciente {paciente.Nombre} {paciente.Apellido}");
            var paciente1 = await _repositorioPaciente.ObtenerIdAsync(Id);
            paciente1.ActualizarDatosPaciente(paciente);
            await _repositorioPaciente.ActualizarAsync(paciente1);
            _logger.LogInformacion($"Paciente actualizado!!");
            return paciente1;
        }

        public async Task<int> ContarPacienteAsync(IEspecificacion<Paciente> especificacion)
        {
            var conteo = await _repositorioPaciente.ConteoAsync(especificacion);
             if (_logger != null)
                _logger.LogInformacion($"Se contarón {conteo} pacientes");
                return conteo;
        }

        public async Task<Paciente> CrearPacienteAsync(Paciente paciente)
        {
             if (_logger != null)
                _logger.LogInformacion($"Se crea el paciente {paciente.Nombre} {paciente.Apellido}");
            await _repositorioPaciente.CrearAsync(paciente);
            if (_logger != null)
                _logger.LogInformacion($"Paciente creado con exito {paciente.Nombre} {paciente.Apellido}");
            return paciente;
        }

        public async Task<Paciente> EliminarPacienteAsync(Paciente paciente, string Id)
        {
            if (_logger != null)
                _logger.LogInformacion($"Se eliminara el paciente {paciente.Nombre} {paciente.Apellido}");
            var pacienteEliminado = await _repositorioPaciente.ObtenerIdAsync(Id);
            await _repositorioPaciente.EliminarAsync(Id);
             if (_logger != null)
                _logger.LogInformacion($"Paciente eliminado con exito {paciente.Nombre} {paciente.Apellido}");
                return paciente;
        }

        public async Task<IReadOnlyList<Paciente>> ObtenerListaPacientesAsync()
        {
            if (_logger != null)
                _logger.LogInformacion($"Obteniendo lista de pacientes.");
            return await _repositorioPaciente.ObtenerListaAsync();
        }

        public async Task<IReadOnlyList<Paciente>> ObtenerPacienteEspecificaAsync(IEspecificacion<Paciente> especificacion)
        {
             if (_logger != null)
                _logger.LogInformacion($"Obteniendo lista de pacientes especifica. tipo especificacion {especificacion.ToString()}");
            return await _repositorioPaciente.ObtenerListaEspecificaAsync(especificacion);
        }

        public async Task<Paciente> ObtenerPacienteIdAsync(string Id)
        {
            if (_logger != null)
                _logger.LogInformacion($"Obteniendo paciente por Id {Id}.");
            return await _repositorioPaciente.ObtenerIdAsync(Id);
        }
    }
}