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
    public class MedicoPersist : IMedicoPersist
    {
        private readonly ProMedContext _context;

        public MedicoPersist(ProMedContext context)
        {
            _context = context;
        }

        public async Task<Medico[]> GetAllMedicosAsync(bool includeHospitais = false)
        {
            IQueryable<Medico> query = _context.Medicos.Include(m => m.RedesSociais);

            if (includeHospitais)
            {
                query = query.Include(m => m.MedicosHospitais).ThenInclude(mh => mh.Hospital);
            }

            query = query.AsNoTracking().OrderBy(m => m.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Medico[]> GetAllMedicosByNomeAsync(string nome, bool includeHospitais = false)
        {
            IQueryable<Medico> query = _context.Medicos.Include(m => m.RedesSociais);

            if (includeHospitais)
            {
                query = query.Include(m => m.MedicosHospitais).ThenInclude(mh => mh.Hospital);
            }

            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Medico> GetMedicoByIdAsync(int medicoId, bool includeHospitais = false)
        {
            IQueryable<Medico> query = _context.Medicos.Include(m => m.RedesSociais);

            if (includeHospitais)
            {
                query = query.Include(m => m.MedicosHospitais).ThenInclude(mh => mh.Hospital);
            }

            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Id == medicoId);

            return await query.FirstOrDefaultAsync();
        }
     
    }
}