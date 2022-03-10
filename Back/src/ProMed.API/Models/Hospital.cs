using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMed.API.Models
{
    public class Hospital
    {
        public int HospitalId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int QtdLeitos { get; set; }
        public string Especialidades { get; set; }
        public string ImagenURL { get; set; }
    }
}