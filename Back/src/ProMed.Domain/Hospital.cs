using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMed.Domain
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int QtdLeitos { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<EspecialidadeHospital> EspecialidadesHospitais { get; set; }
        public IEnumerable<MedicoHospital> MedicosHospitais { get; set; }
    }
}