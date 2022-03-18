using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProMed.Domain;
using ProMed.Persistence.Contextos;
using ProMed.Persistence.Contratos;

namespace ProMed.Persistence
{
    public class HospitalPersist : IHospitalPersist
    {
        private readonly ProMedContext _context;

        public HospitalPersist(ProMedContext context)
        {
            _context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Hospital[]> GetAllHospitaisAsync(bool includeMedicos = false, bool includeEspecialidades = false)
        {
            IQueryable<Hospital> query = _context.Hospitais.Include(h => h.RedesSociais);

            if (includeMedicos)
            {
                query = query.Include(h => h.MedicosHospitais).ThenInclude(mh => mh.Medico);
            }
            if (includeEspecialidades)
            {
                query = query.Include(h => h.EspecialidadesHospitais).ThenInclude(eh => eh.Especialidade);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Hospital[]> GetAllHospitaisByNomeAsync(string nome, bool includeMedicos = false, bool includeEspecialidades = false)
        {
            IQueryable<Hospital> query = _context.Hospitais.Include(h => h.RedesSociais);

            if (includeMedicos)
            {
                query = query.Include(h => h.MedicosHospitais).ThenInclude(mh => mh.Medico);
            }
            if (includeEspecialidades)
            {
                query = query.Include(h => h.EspecialidadesHospitais).ThenInclude(eh => eh.Especialidade);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id).Where(h => h.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Hospital> GetHospitalByIdAsync(int hospitalId, bool includeMedicos = false, bool includeEspecialidades = false)
        {
            IQueryable<Hospital> query = _context.Hospitais.Include(h => h.RedesSociais);

            if (includeMedicos)
            {
                query = query.Include(h => h.MedicosHospitais).ThenInclude(mh => mh.Medico);
            }
            if (includeEspecialidades)
            {
                query = query.Include(h => h.EspecialidadesHospitais).ThenInclude(eh => eh.Especialidade);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id).Where(h => h.Id == hospitalId);

            return await query.FirstOrDefaultAsync();
        }
     
    }
}