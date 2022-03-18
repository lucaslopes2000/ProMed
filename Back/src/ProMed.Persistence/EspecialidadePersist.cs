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
    public class EspecialidadePersist : IEspecialidadePersist
    {
        private readonly ProMedContext _context;

        public EspecialidadePersist(ProMedContext context)
        {
            _context = context;
        }

        public async Task<Especialidade[]> GetAllEspecialidadesAsync(bool includeHospitais = false)
        {
            IQueryable<Especialidade> query = _context.Especialidades;

            if (includeHospitais)
            {
                query = query.Include(e => e.EspecialidadesHospitais).ThenInclude(eh => eh.Hospital);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Especialidade[]> GetAllEspecialidadesByNomeAsync(string nome, bool includeHospitais = false)
        {
            IQueryable<Especialidade> query = _context.Especialidades;

            if (includeHospitais)
            {
                query = query.Include(e => e.EspecialidadesHospitais).ThenInclude(eh => eh.Hospital);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Especialidade> GetEspecialidadeByIdAsync(int especialidadeId, bool includeHospitais = false)
        {
            IQueryable<Especialidade> query = _context.Especialidades;

            if (includeHospitais)
            {
                query = query.Include(e => e.EspecialidadesHospitais).ThenInclude(eh => eh.Hospital);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == especialidadeId);

            return await query.FirstOrDefaultAsync();
        }
     
    }
}