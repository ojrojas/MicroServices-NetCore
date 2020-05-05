using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexos.Core.Entidades;

namespace Nexos.Infraestructure.Data.ConfigureTables
{
    public class ConfiguracionMedicos : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.Property(bi => bi.Apellido)
               .IsRequired(true)
               .HasColumnType("varchar(30)");

            builder.Property(bi => bi.Nombre)
           .IsRequired(true)
           .HasColumnType("varchar(30)");
            builder.Property(bi => bi.Especialidad)
           .IsRequired(true)
           .HasColumnType("varchar(50)");
        }
    }
}