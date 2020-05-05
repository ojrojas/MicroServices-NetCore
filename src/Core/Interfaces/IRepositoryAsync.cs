using System.Collections.Generic;
using System.Threading.Tasks;
using Nexos.Core.Entidades;

namespace  Nexos.Core.Interfaces
{
    public interface IRepositoryAsync<T> where T : BaseEntity, IAggregateRoot 
    {
        Task<T> ObtenerIdAsync(string Id);
        Task<IReadOnlyList<T>> ObtenerListaAsync();
        Task<IReadOnlyList<T>> ObtenerListaEspecificaAsync(IEspecificacion<T> especificacion);
        Task<T> CrearAsync(T entidad);
        Task ActualizarAsync(T entidad);
        Task EliminarAsync(string Id);
        Task<int> ConteoAsync(IEspecificacion<T> especificacion);
    }
}