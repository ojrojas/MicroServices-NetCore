using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nexos.Core.Entidades;

namespace Nexos.Infraestructure.Data
{
    public class NexosContext : DbContext
    {
        public NexosContext(DbContextOptions<NexosContext> options) : base(options)
        {}
            public DbSet<Medico> Medicos { get; set; }
            public DbSet<Paciente> Pacientes { get; set; }

            protected override void OnModelCreating(ModelBuilder model)
            {
                base.OnModelCreating(model);
                model.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
    }
}