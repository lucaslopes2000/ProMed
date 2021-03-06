// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProMed.Persistence.Contextos;

namespace ProMed.Persistence.Migrations
{
    [DbContext(typeof(ProMedContext))]
    [Migration("20220316034637_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ProMed.Domain.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("ProMed.Domain.EspecialidadeHospital", b =>
                {
                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HospitalId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EspecialidadeId", "HospitalId");

                    b.HasIndex("HospitalId");

                    b.ToTable("EspecialidadesHospitais");
                });

            modelBuilder.Entity("ProMed.Domain.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdLeitos")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Hospitais");
                });

            modelBuilder.Entity("ProMed.Domain.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CRM")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiniCurriculo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadeId");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("ProMed.Domain.MedicoHospital", b =>
                {
                    b.Property<int>("MedicoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HospitalId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MedicoId", "HospitalId");

                    b.HasIndex("HospitalId");

                    b.ToTable("MedicosHospitais");
                });

            modelBuilder.Entity("ProMed.Domain.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HospitalId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MedicoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("MedicoId");

                    b.ToTable("RedesSociais");
                });

            modelBuilder.Entity("ProMed.Domain.EspecialidadeHospital", b =>
                {
                    b.HasOne("ProMed.Domain.Especialidade", "Especialidade")
                        .WithMany("EspecialidadesHospitais")
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProMed.Domain.Hospital", "Hospital")
                        .WithMany("EspecialidadesHospitais")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("ProMed.Domain.Medico", b =>
                {
                    b.HasOne("ProMed.Domain.Especialidade", "Especialidade")
                        .WithMany("Medicos")
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");
                });

            modelBuilder.Entity("ProMed.Domain.MedicoHospital", b =>
                {
                    b.HasOne("ProMed.Domain.Hospital", "Hospital")
                        .WithMany("MedicosHospitais")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProMed.Domain.Medico", "Medico")
                        .WithMany("MedicosHospitais")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("ProMed.Domain.RedeSocial", b =>
                {
                    b.HasOne("ProMed.Domain.Hospital", "Hospital")
                        .WithMany("RedesSociais")
                        .HasForeignKey("HospitalId");

                    b.HasOne("ProMed.Domain.Medico", "Medico")
                        .WithMany("RedesSociais")
                        .HasForeignKey("MedicoId");

                    b.Navigation("Hospital");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("ProMed.Domain.Especialidade", b =>
                {
                    b.Navigation("EspecialidadesHospitais");

                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("ProMed.Domain.Hospital", b =>
                {
                    b.Navigation("EspecialidadesHospitais");

                    b.Navigation("MedicosHospitais");

                    b.Navigation("RedesSociais");
                });

            modelBuilder.Entity("ProMed.Domain.Medico", b =>
                {
                    b.Navigation("MedicosHospitais");

                    b.Navigation("RedesSociais");
                });
#pragma warning restore 612, 618
        }
    }
}
