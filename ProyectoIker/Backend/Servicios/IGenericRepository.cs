using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace UD4_Ejemplo1.Backend.Servicios
{
    /// <summary>
    /// Contrato de repositorio genérico para operaciones CRUD comunes usando Entity Framework Core.
    /// Las implementaciones proporcionan un envoltorio ligero alrededor de un DbContext y su DbSet{T}.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        // Lectura
        Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        Task<List<T>> ListAsync(
            bool asNoTracking = true,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[] includes);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);

        // Escritura
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteByIdAsync(object id, CancellationToken cancellationToken = default);

        // Query avanzada (para construir consultas personalizadas en repositorios específicos)
        IQueryable<T> Query(
            bool asNoTracking = true,
            params Expression<Func<T, object>>[] includes);
    }
}