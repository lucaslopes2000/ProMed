using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMed.Domain
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Medico> Medicos { get; set; }
        public IEnumerable<EspecialidadeHospital> EspecialidadesHospitais { get; set; }
    }
}