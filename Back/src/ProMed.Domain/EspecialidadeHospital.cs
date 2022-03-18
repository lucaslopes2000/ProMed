using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMed.Domain
{
    public class EspecialidadeHospital
    {
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}