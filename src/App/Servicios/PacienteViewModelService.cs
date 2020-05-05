using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.ViewModels;
using Microsoft.Extensions.Logging;
using Nexos.Core.Entidades;
using Nexos.Core.Interfaces;

namespace App.Servicios
{
    public class PacienteViewModelService : IPacienteViewModelService
    {
        private readonly IRepositoryAsync<Paciente> _repositoryPaciente;
        private readonly ILogger<PacienteViewModelService> _logger;
        private readonly IRepositoryAsync<Medico> _repositoryMedico;

        public PacienteViewModelService(
            IRepositoryAsync<Paciente> repositorioPaciente,
            IRepositoryAsync<Medico> repositorioMedico,
            ILoggerFactory factoryLogger)
        {
            _repositoryPaciente = repositorioPaciente;
            _repositoryMedico = repositorioMedico;
            _logger = factoryLogger.CreateLogger<PacienteViewModelService>();
        }

        public async Task<PacienteViewModel> ActualizarPaciente(PacienteViewModel paciente, string Id)
        {
             try
            {
                _logger.LogInformation($"Se esta aculizando el paciente {paciente.Nombre} {paciente.Apellido}");
                var paciente1 = await _repositoryPaciente.ObtenerIdAsync(Id);
                paciente1.ActualizarDatosPaciente(paciente.ConvertirPacienteViewModelToPaciente(paciente));
                await _repositoryPaciente.ActualizarAsync(paciente1);
                _logger.LogInformation($"Paciente actualizado!!");
                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> ContarPacientes(IEspecificacion<Paciente> espeficicacion)
        {
             try
            {
                var conteo = await _repositoryPaciente.ConteoAsync(espeficicacion);
                _logger.LogInformation($"Se contarón {conteo} Pacientes");
                return conteo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PacienteViewModel> EliminarPaciente(PacienteViewModel paciente, string Id)
        {
            try
            {
                _logger.LogInformation($"Se eliminara el paciente {paciente.Nombre} {paciente.Apellido}");
                var pacienteEliminado = await _repositoryPaciente.ObtenerIdAsync(Id);
                await _repositoryPaciente.EliminarAsync(Id);
                _logger.LogInformation($"paciente eliminado con exito {paciente.Nombre} {paciente.Apellido}");
                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PacienteViewModel> GuardarPaciente(PacienteViewModel paciente)
        {
              try
            {
                _logger.LogInformation($"Se crea el paciente {paciente.Nombre} {paciente.Apellido}");
                paciente.Medico = await _repositoryMedico.ObtenerIdAsync(paciente.MedicoId);
                await _repositoryPaciente.CrearAsync(paciente.ConvertirPacienteViewModelToPaciente(paciente));
                _logger.LogInformation($"paciente creado con exito {paciente.Nombre} {paciente.Apellido}");
                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IReadOnlyList<PacienteViewModel>> ObtenerPacienteEspecificacion(IEspecificacion<Paciente> espeficicacion)
        {
            try
            {
                _logger.LogInformation($"Obteniendo lista de pacientes especifica. tipo especificacion {espeficicacion.ToString()}");
                var paciente = new PacienteViewModel();
                return paciente.ConvertirListaMedicoToListaMedicoViewModel(
                    await _repositoryPaciente.ObtenerListaEspecificaAsync(
                        espeficicacion));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PacienteViewModel> ObtenerPacienteId(string Id)
        {
             try
            {
                _logger.LogInformation($"Obteniendo paciente por Id {Id}.");
                var paciente = await _repositoryPaciente.ObtenerIdAsync(Id);
                return new PacienteViewModel
                {
                    Id = paciente.Id,
                    Nombre = paciente.Nombre,
                    Apellido = paciente.Apellido,
                    SegundoApellido = paciente.SegundoApellido,
                    SegundoNombre = paciente.SegundoNombre,
                    NumeroSeguroSocial = paciente.NumeroSeguroSocial,
                    Medico = paciente.Medico,
                    MedicoId = paciente.MedicoId
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IReadOnlyList<PacienteViewModel>> ObtenerPacientes()
        {
            try
            {
                _logger.LogInformation($"Obteniendo lista de medicos.");
                var pacientes =  new PacienteViewModel()
                .ConvertirListaMedicoToListaMedicoViewModel(
                    await _repositoryPaciente.ObtenerListaAsync());
                foreach(var i in pacientes)
                    i.Medico = await _repositoryMedico.ObtenerIdAsync(i.MedicoId);

                return pacientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}