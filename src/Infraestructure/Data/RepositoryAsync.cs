using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nexos.Core.Entidades;
using Nexos.Core.Interfaces;

namespace Nexos.Infraestructure.Data
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity, IAggregateRoot
    {
        private readonly NexosContext _context;

        public RepositoryAsync(NexosContext context)
        {
            _context = context;
        }

        public async Task ActualizarAsync(T entidad)
        {
             _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<int> ConteoAsync(IEspecificacion<T> especificacion)
        {
             return await AplicarEspecificacion(especificacion).CountAsync();
        }

        public async Task<T> CrearAsync(T entidad)
        {
            await _context.Set<T>().AddAsync(entidad);
            await _context.SaveChangesAsync();

            return entidad;
        }

        public async Task EliminarAsync(string Id)
        {
            var entidad = await ObtenerIdAsync(Id);
            _context.Set<T>().Remove(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<T> ObtenerIdAsync(string Id)
        {
             return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<IReadOnlyList<T>> ObtenerListaAsync()
        {
             return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ObtenerListaEspecificaAsync(IEspecificacion<T> especificacion)
        {
            return await AplicarEspecificacion(especificacion).ToListAsync();
        }

        private IQueryable<T> AplicarEspecificacion(IEspecificacion<T> spec)
        {
            return EvaluadorEspecificacion<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}