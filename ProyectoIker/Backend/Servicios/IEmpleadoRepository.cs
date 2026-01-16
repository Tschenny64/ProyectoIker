using ProyectoIker.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIker.Backend.Servicios
{
    public interface IEmpleadoRepository : IGenericRepository<Empleado>
    {
        Task<Empleado?> GetByDniAsync(string dni, CancellationToken cancellationToken = default);
        Task<List<Empleado>> GetByRolAsync(int rolId, CancellationToken cancellationToken = default);
        Task<bool> ExistsByTelefonoAsync(string telefono, CancellationToken cancellationToken = default);
    }
}