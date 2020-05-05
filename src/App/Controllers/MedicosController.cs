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
    public class MedicosController : ControllerBase
    {
        private readonly ILogger<MedicosController> _loger;
        private readonly IMedicoViewModelService _service;

        public MedicosController(
            ILogger<MedicosController> loger,
            IMedicoViewModelService service)
        {
            _loger = loger;
            _service = service;
        }

        [HttpGet]
        [Route("ObtenerMedicos")]
        public async Task<IEnumerable<MedicoViewModel>> ObtenerMedicos()
        {
            return await _service.ObtenerMedicos();
        }

        [HttpGet]
        [Route("ObtenerMedicoId/Id/{Id}")]
        public async Task<MedicoViewModel> ObtenerMedicoId(string Id)
        {
            return await _service.ObtenerMedicoId(Id);
        }

        [HttpPost]
        [Route("CrearMedicos")]
        public async Task<IActionResult> CrearMedicos(MedicoViewModel medico)
        {
            if (medico is null)
                throw new ArgumentNullException(nameof(medico));
            if (ModelState.IsValid)
                return Ok(await _service.GuardarMedico(
                    medico));
            return BadRequest(medico.ToString());
        }

        [HttpPost]
        [Route("ActualizarMedicos")]
        public async Task<IActionResult> ActualizarMedicos(MedicoViewModel medico, string Id) 
        {
            if(string.IsNullOrEmpty(Id))
            throw new ArgumentNullException(Id);
            if(ModelState.IsValid)
            return Ok(await _service.ActualizarMedico(medico, Id));
            return BadRequest(medico.ToString());
        }

        [HttpPost]
        [Route("EliminarMedicos")]
        public async Task<IActionResult> EliminarMedicos(MedicoViewModel medico, string Id) 
        {
            if(string.IsNullOrEmpty(Id))
            throw new ArgumentNullException(Id);
            if(ModelState.IsValid)
            return Ok(await _service.EliminarMedico(medico, Id));
            return BadRequest(medico.ToString());
        }
    }
}