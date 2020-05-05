﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexos.Infraestructure.Data;

namespace Nexos.Infraestructure.Data.Migrations
{
    [DbContext(typeof(NexosContext))]
    partial class NexosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nexos.Core.Entidades.Medico", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("Nexos.Core.Entidades.Paciente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("MedicoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NumeroSeguroSocial")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SegundoNombre")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Nexos.Core.Entidades.Paciente", b =>
                {
                    b.HasOne("Nexos.Core.Entidades.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId");
                });
#pragma warning restore 612, 618
        }
    }
}