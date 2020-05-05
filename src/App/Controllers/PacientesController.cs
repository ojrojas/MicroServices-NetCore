using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Servicios;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nexos.Core.Entidades;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly ILogger<PacientesController> _loger;
        private readonly IPacienteViewModelService _service;

        public PacientesController(
            ILogger<PacientesController> loger,
            IPacienteViewModelService service)
        {
            _loger = loger;
            _service = service;
        }

        [HttpGet]
        [Route("ObtenerPacientes")]
        public async Task<IEnumerable<PacienteViewModel>> ObtenerPacientes()
        {
            return await _service.ObtenerPacientes();
        }

        [HttpGet]
        [Route("ObtenerPacienteId/Id/{Id}")]
        public async Task<PacienteViewModel> ObtenerPacienteId(string Id)
        {
            return await _service.ObtenerPacienteId(Id);
        }

        [HttpPost]
        [Route("CrearPacientes")]
        public async Task<IActionResult> CrearPacientes(PacienteViewModel paciente)
        {
            if (paciente is null)
                throw new ArgumentNullException(nameof(paciente));
            if (ModelState.IsValid)
                return Ok(await _service.GuardarPaciente(
                    paciente));
            return BadRequest(paciente.ToString());
        }

        [HttpPost]
        [Route("ActualizarPacientes")]
        public async Task<IActionResult> ActualizarPacientes(PacienteViewModel paciente, string Id) 
        {
            if(string.IsNullOrEmpty(Id))
            throw new ArgumentNullException(Id);
            if(ModelState.IsValid)
            return Ok(await _service.ActualizarPaciente(paciente, Id));
            return BadRequest(paciente.ToString());
        }

        [HttpPost]
        [Route("EliminarPacientes")]
        public async Task<IActionResult> EliminarPacientes(PacienteViewModel paciente, string Id) 
        {
            if(string.IsNullOrEmpty(Id))
            throw new ArgumentNullException(Id);
            if(ModelState.IsValid)
            return Ok(await _service.EliminarPaciente(paciente, Id));
            return BadRequest(paciente.ToString());
        }
    }
}