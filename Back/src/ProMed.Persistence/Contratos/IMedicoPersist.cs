using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProMed.Domain;

namespace ProMed.Persistence.Contratos
{
    public interface IMedicoPersist
    {      
        //MEDICO
        Task<Medico[]> GetAllMedicosByNomeAsync(string nome, bool includeHospitais);
        Task<Medico[]> GetAllMedicosAsync(bool includeHospitais);
        Task<Medico> GetMedicoByIdAsync(int medicoId, bool includeHospitais);
    }
}