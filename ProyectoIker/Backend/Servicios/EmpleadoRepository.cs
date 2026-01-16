using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProyectoIker.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProyectoIker.Backend.Servicios
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(ProyectoContext context, ILogger<GenericRepository<Empleado>> logger)
            : base(context, logger)
        {
        }

        public async Task<Empleado?> GetByDniAsync(string dni, CancellationToken cancellationToken = default)
        {
            return await Query(asNoTracking: true)
                         .FirstOrDefaultAsync(e => e.Dni == dni, cancellationToken)
                         .ConfigureAwait(false);
        }

        public async Task<List<Empleado>> GetByRolAsync(int rolId, CancellationToken cancellationToken = default)
        {
            return await Query(asNoTracking: true)
                         .Where(e => e.RolId == rolId)
                         .ToListAsync(cancellationToken)
                         .ConfigureAwait(false);
        }

        public async Task<bool> ExistsByTelefonoAsync(string telefono, CancellationToken cancellationToken = default)
        {
            return await Query(asNoTracking: true)
                         .AnyAsync(e => e.Telefono == telefono, cancellationToken)
                         .ConfigureAwait(false);
        }
        public async Task<bool> LoginAsync(string usuario, string password, CancellationToken cancellationToken = default)
        {
            var empleado = await Query(asNoTracking: true)
                .FirstOrDefaultAsync(e => e.Usuario == usuario, cancellationToken)
                .ConfigureAwait(false);

            if (empleado != null && empleado.Password == password)
            {
                return true;
            }

            return false;
        }

    }
}