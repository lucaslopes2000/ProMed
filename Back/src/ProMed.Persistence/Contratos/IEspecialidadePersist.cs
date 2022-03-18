using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProMed.Domain;

namespace ProMed.Persistence.Contratos
{
    public interface IEspecialidadePersist
    {
        //ESPECIALIDADE
        Task<Especialidade[]> GetAllEspecialidadesByNomeAsync(string nome, bool includeHospitais);
        Task<Especialidade[]> GetAllEspecialidadesAsync(bool includeHospitais);
        Task<Especialidade> GetEspecialidadeByIdAsync(int especialidadeId, bool includeHospitais);
    }
}