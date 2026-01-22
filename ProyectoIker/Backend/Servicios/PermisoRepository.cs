using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using ProyectoIker.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIker.Backend.Servicios
{
    public class PermisoRepository : GenericRepository<Permiso>, IPermisoRepository
    {
        public PermisoRepository(ProyectoContext context, ILogger<GenericRepository<Permiso>> logger) : base(context, logger)
        {
        }
    }
}
