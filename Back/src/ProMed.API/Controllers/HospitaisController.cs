using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProMed.Application.Contratos;
using ProMed.Domain;
using ProMed.Persistence.Contextos;

namespace ProMed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitaisController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;
        public HospitaisController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var hospitais = await _hospitalService.GetAllHospitaisAsync(true, true);
                if (hospitais == null) return NotFound("Nenhum hospital encontrado.");

                return Ok(hospitais);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar hospitais. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var hospital = await _hospitalService.GetHospitalByIdAsync(id, true, true);
                if (hospital == null) return NotFound("Hospital por Id não encontrado.");

                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar hospital. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var hospitais = await _hospitalService.GetAllHospitaisByNomeAsync(nome, true, true);
                if (hospitais == null) return NotFound("Hospital por Nome não encontrado.");

                return Ok(hospitais);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar hospitais. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Hospital model)
        {
            try
            {
                var hospital = await _hospitalService.AddHospital(model);
                if (hospital == null) return BadRequest("Erro ao tentar adicionar hospital.");

                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar hospital. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Hospital model)
        {
            try
            {
                var hospital = await _hospitalService.UpdadeHospital(id, model);
                if (hospital == null) return BadRequest("Erro ao tentar atualizar hospital.");

                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar hospital. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _hospitalService.DeleteHospital(id) ? Ok("Deletado.") : BadRequest("Hospital não deletado.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar hospital. Erro: {ex.Message}");
            }
        }
    }
}
