using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMed.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public int? MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}