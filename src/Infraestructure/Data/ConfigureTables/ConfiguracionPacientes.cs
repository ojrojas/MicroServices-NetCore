using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexos.Core.Entidades;

namespace Nexos.Infraestructure.Data.ConfigureTables
{
    public class ConfiguracionPacientes : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
           builder.Property(bi => bi.Apellido)
               .IsRequired(true)
               .HasColumnType("varchar(30)");

            builder.Property(bi => bi.SegundoApellido)
               .IsRequired(true)
               .HasColumnType("varchar(30)");
            
            builder.Property(bi => bi.Nombre)
               .IsRequired(true)
               .HasColumnType("varchar(30)");

            builder.Property(bi => bi.SegundoNombre)
               .IsRequired(true)
               .HasColumnType("varchar(30)");

            builder.Property(bi => bi.NumeroSeguroSocial)
               .IsRequired(true)
               .HasColumnType("varchar(10)");
        }
    }
}