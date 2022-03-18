using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProMed.Domain;

namespace ProMed.Application.Contratos
{
    public interface IHospitalService
    {
        Task<Hospital> AddHospital(Hospital model);
        Task<Hospital> UpdadeHospital(int hostitalId, Hospital model);
        Task<bool> DeleteHospital(int hostitalId);

        Task<Hospital[]> GetAllHospitaisAsync(bool includeMedicos = false, bool includeEspecialidades = false);
        Task<Hospital[]> GetAllHospitaisByNomeAsync(string nome, bool includeMedicos = false, bool includeEspecialidades = false);
        Task<Hospital> GetHospitalByIdAsync(int hospitalId, bool includeMedicos = false, bool includeEspecialidades = false);
    }
}