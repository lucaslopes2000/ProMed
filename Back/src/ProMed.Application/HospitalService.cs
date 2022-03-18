using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProMed.Application.Contratos;
using ProMed.Domain;
using ProMed.Persistence.Contratos;

namespace ProMed.Application
{
    public class HospitalService : IHospitalService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IHospitalPersist _hospitalPersist;

        public HospitalService(IGeralPersist geralPersist, IHospitalPersist hospitalPersist)
        {
            _geralPersist = geralPersist;
            _hospitalPersist = hospitalPersist;
        }

        public async Task<Hospital> AddHospital(Hospital model)
        {
            try
            {
                _geralPersist.Add<Hospital>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _hospitalPersist.GetHospitalByIdAsync(model.Id, false, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Hospital> UpdadeHospital(int hostitalId, Hospital model)
        {
            try
            {
                var hospital = await _hospitalPersist.GetHospitalByIdAsync(hostitalId, false, false);
                if (hospital == null) return null;

                model.Id = hospital.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _hospitalPersist.GetHospitalByIdAsync(model.Id, false, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteHospital(int hostitalId)
        {
            try
            {
                var hospital = await _hospitalPersist.GetHospitalByIdAsync(hostitalId, false, false);
                if (hospital == null) throw new Exception("Hospital para delete não encontrado.");

                _geralPersist.Delete<Hospital>(hospital);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Hospital[]> GetAllHospitaisAsync(bool includeMedicos = false, bool includeEspecialidades = false)
        {
            try
            {
                var hospitais = await _hospitalPersist.GetAllHospitaisAsync(includeMedicos, includeEspecialidades);
                if (hospitais == null) return null;

                return hospitais;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Hospital[]> GetAllHospitaisByNomeAsync(string nome, bool includeMedicos = false, bool includeEspecialidades = false)
        {
            try
            {
                var hospitais = await _hospitalPersist.GetAllHospitaisByNomeAsync(nome, includeMedicos, includeEspecialidades);
                if (hospitais == null) return null;

                return hospitais;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Hospital> GetHospitalByIdAsync(int hospitalId, bool includeMedicos = false, bool includeEspecialidades = false)
        {
            try
            {
                var hospital = await _hospitalPersist.GetHospitalByIdAsync(hospitalId, includeMedicos, includeEspecialidades);
                if (hospital == null) return null;

                return hospital;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}