using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.ViewModels;
using Microsoft.Extensions.Logging;
using Nexos.Core.Entidades;
using Nexos.Core.Interfaces;

namespace App.Servicios
{
    public class MedicoViewModelService : IMedicoViewModelService
    {
        private readonly IRepositoryAsync<Medico> _repositoryMedico;
        private readonly ILogger<MedicoViewModelService> _logger;

        public MedicoViewModelService(
            IRepositoryAsync<Medico> repositorioMedico,
            ILoggerFactory factoryLogger)
        {
            _repositoryMedico = repositorioMedico;
            _logger = factoryLogger.CreateLogger<MedicoViewModelService>();
        }

        public async Task<MedicoViewModel> ActualizarMedico(MedicoViewModel medico, string Id)
        {
            try
            {
                _logger.LogInformation($"Se esta aculizando el medico {medico.Nombre} {medico.Apellido}");
                var medico1 = await _repositoryMedico.ObtenerIdAsync(Id);
                medico1.ActualizarDatosMedico(medico.ConvertirMedicoViewModelToMedico(medico));
                await _repositoryMedico.ActualizarAsync(medico1);
                _logger.LogInformation($"Medico actualizado!!");
                return medico;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<MedicoViewModel> EliminarMedico(MedicoViewModel medico, string Id)
        {
            try
            {
                _logger.LogInformation($"Se eliminara el medico {medico.Nombre} {medico.Apellido}");
                var medicoEliminado = await _repositoryMedico.ObtenerIdAsync(Id);
                await _repositoryMedico.EliminarAsync(Id);
                _logger.LogInformation($"Medico eliminado con exito {medico.Nombre} {medico.Apellido}");
                return medico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<MedicoViewModel> GuardarMedico(MedicoViewModel medico)
        {
            try
            {
                _logger.LogInformation($"Se crea el medico {medico.Nombre} {medico.Apellido}");
                await _repositoryMedico.CrearAsync(medico.ConvertirMedicoViewModelToMedico(medico));
                _logger.LogInformation($"medico creado con exito {medico.Nombre} {medico.Apellido}");
                return medico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IReadOnlyList<MedicoViewModel>> ObtenerMedicoEspecificacion(IEspecificacion<Medico> especificacion)
        {
            try
            {
                _logger.LogInformation($"Obteniendo lista de medicos especifica. tipo especificacion {especificacion.ToString()}");
                var medico = new MedicoViewModel();
                return medico.ConvertirListaMedicoToListaMedicoViewModel(
                    await _repositoryMedico.ObtenerListaEspecificaAsync(
                        especificacion));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<MedicoViewModel> ObtenerMedicoId(string Id)
        {
            try
            {
                _logger.LogInformation($"Obteniendo medico por Id {Id}.");
                var medico = await _repositoryMedico.ObtenerIdAsync(Id);
                return new MedicoViewModel
                {
                    Id = medico.Id,
                    Nombre = medico.Nombre,
                    Apellido = medico.Apellido,
                    Especialidad = medico.Especialidad
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IReadOnlyList<MedicoViewModel>> ObtenerMedicos()
        {
            try
            {
                _logger.LogInformation($"Obteniendo lista de medicos.");
                var medico = new MedicoViewModel();
                return medico.ConvertirListaMedicoToListaMedicoViewModel(await _repositoryMedico.ObtenerListaAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> ContarMedicos(IEspecificacion<Medico> especificacion)
        {
            try
            {
                var conteo = await _repositoryMedico.ConteoAsync(especificacion);
                _logger.LogInformation($"Se contarón {conteo} Medicos");
                return conteo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}