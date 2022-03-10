using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProMed.API.Models;

namespace ProMed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        public IEnumerable<Hospital> _hospital = new Hospital[] {
            new Hospital() {
                HospitalId = 1,
                Nome = "Hospital Pacini",
                Endereco = "Asa sul, Brasília -DF",
                QtdLeitos = 20,
                Especialidades = "Oftalmologia",
                ImagenURL = "foto1.png"
            },
            new Hospital() {
                HospitalId = 2,
                Nome = "Hospital Santa Helena",
                Endereco = "Asa norte, Brasília -DF",
                QtdLeitos = 100,
                Especialidades = "Clinico geral",
                ImagenURL = "foto2.png"
            }
        };

        public HospitalController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Hospital> Get()
        {
            return _hospital;
        }

        [HttpGet("{id}")]
        public IEnumerable<Hospital> GetById(int id)
        {
            return _hospital.Where(hospital => hospital.HospitalId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}
