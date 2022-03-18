using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMed.Domain
{
    public class MedicoHospital
    {
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}