using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProyectoIker.Backend.Modelo;
using System.Linq.Expressions;

namespace ProyectoIker.Backend.Servicios
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            protected readonly DbContext _context;
            protected readonly DbSet<T> _dbSet;
            protected readonly ILogger<GenericRepository<T>> _logger;

            public GenericRepository(DbContext context, ILogger<GenericRepository<T>> logger)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _dbSet = _context.Set<T>();
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            // -------------------
            // Lectura
            // -------------------
            public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
            {
                // DbSet.FindAsync usa la clave primaria; acepta valores compuestos.
                var entity = await _dbSet.FindAsync([id], cancellationToken).ConfigureAwait(false);
                return entity;
            }

            public async Task<List<T>> ListAsync(
                bool asNoTracking = true,
                CancellationToken cancellationToken = default,
                params Expression<Func<T, object>>[] includes)
            {
                var query = BuildQuery(asNoTracking, includes);
                return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
            }

            public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            {
                return await _dbSet.AnyAsync(predicate, cancellationToken).ConfigureAwait(false);
            }

            public async Task<int> CountAsync(
                Expression<Func<T, bool>>? predicate = null,
                CancellationToken cancellationToken = default)
            {
                return predicate is null
                    ? await _dbSet.CountAsync(cancellationToken).ConfigureAwait(false)
                    : await _dbSet.CountAsync(predicate, cancellationToken).ConfigureAwait(false);
            }

            // -------------------
            // Escritura
            // -------------------
            public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
            {
                ArgumentNullException.ThrowIfNull(entity);
                await _dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                _logger.LogInformation("Entidad {Entity} añadida.", typeof(T).Name);
                return entity;
            }

            public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            {
                ArgumentNullException.ThrowIfNull(entities);
                await _dbSet.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                _logger.LogInformation("Añadidas {Count} entidades {Entity}.", entities.Count(), typeof(T).Name);
            }

            public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
            {
                ArgumentNullException.ThrowIfNull(entity);
                _dbSet.Update(entity);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                _logger.LogInformation("Entidad {Entity} actualizada.", typeof(T).Name);
            }

            public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
            {
                ArgumentNullException.ThrowIfNull(entity);
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                _logger.LogInformation("Entidad {Entity} eliminada.", typeof(T).Name);
            }

            public async Task<bool> DeleteByIdAsync(object id, CancellationToken cancellationToken = default)
            {
                var entity = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
                if (entity is null)
                {
                    _logger.LogWarning("Intento de eliminación: {Entity} con id {Id} no encontrada.", typeof(T).Name, id);
                    return false;
                }

                _dbSet.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                _logger.LogInformation("{Entity} con id {Id} eliminada.", typeof(T).Name, id);
                return true;
            }

            // -------------------
            // Query avanzada
            // -------------------
            public IQueryable<T> Query(bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
            {
                return BuildQuery(asNoTracking, includes);
            }

            protected IQueryable<T> BuildQuery(bool asNoTracking, params Expression<Func<T, object>>[] includes)
            {
                IQueryable<T> query = _dbSet;

                if (asNoTracking)
                    query = query.AsNoTracking();

                if (includes is { Length: > 0 })
                {
                    foreach (var include in includes)
                        query = query.Include(include);
                }

                return query;
            }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
    }