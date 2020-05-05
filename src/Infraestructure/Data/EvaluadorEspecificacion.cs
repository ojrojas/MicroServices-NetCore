using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nexos.Core.Entidades;
using Nexos.Core.Interfaces;

namespace Nexos.Infraestructure.Data
{
    public class EvaluadorEspecificacion<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IEspecificacion<T> especificacion)
        {
            var query = inputQuery;

            // modify the IQueryable using the especificacion's criteria expression
            if (especificacion.Criteria != null)
            {
                query = query.Where(especificacion.Criteria);
            }

            // Includes all expression-based includes
            query = especificacion.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Include any string-based include statements
            query = especificacion.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Apply ordering if expressions are set
            if (especificacion.OrderBy != null)
            {
                query = query.OrderBy(especificacion.OrderBy);
            }
            else if (especificacion.OrderByDescending != null)
            {
                query = query.OrderByDescending(especificacion.OrderByDescending);
            }

            if (especificacion.GroupBy != null)
            {
                query = query.GroupBy(especificacion.GroupBy).SelectMany(x => x);
            }

            // Apply paging if enabled
            if (especificacion.IsPagingEnabled)
            {
                query = query.Skip(especificacion.Skip)
                             .Take(especificacion.Take);
            }
            return query;
        }
    }
}