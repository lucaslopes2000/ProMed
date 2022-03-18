using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProMed.Domain;

namespace ProMed.Persistence.Contratos
{
    public interface IHospitalPersist
    {     
        //HOSPITAL
        Task<Hospital[]> GetAllHospitaisByNomeAsync(string nome, bool includeMedicos = false, bool includeEspecialidades = false);
        Task<Hospital[]> GetAllHospitaisAsync(bool includeMedicos = false, bool includeEspecialidades = false);
        Task<Hospital> GetHospitalByIdAsync(int hospitalId, bool includeMedicos = false, bool includeEspecialidades = false);
    }
}