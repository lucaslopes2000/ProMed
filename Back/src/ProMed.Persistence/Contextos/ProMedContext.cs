using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProMed.Domain;

namespace ProMed.Persistence.Contextos
{
    public class ProMedContext : DbContext
    {
        public ProMedContext(DbContextOptions<ProMedContext> options) : base(options) { }
        public DbSet<Hospital> Hospitais { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<EspecialidadeHospital> EspecialidadesHospitais { get; set; }
        public DbSet<MedicoHospital> MedicosHospitais { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EspecialidadeHospital>().HasKey(EH => new {EH.EspecialidadeId, EH.HospitalId});
            modelBuilder.Entity<MedicoHospital>().HasKey(MH => new {MH.MedicoId, MH.HospitalId});

            modelBuilder.Entity<Hospital>().HasMany(h => h.RedesSociais).WithOne(rs => rs.Hospital).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Medico>().HasMany(m => m.RedesSociais).WithOne(rs => rs.Medico).OnDelete(DeleteBehavior.Cascade);
        }
    }
}