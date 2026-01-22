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
    public class ReparacioneRepository : GenericRepository<Reparacione>, IReparacioneRepository
    {
        public ReparacioneRepository(ProyectoContext context, ILogger<GenericRepository<Reparacione>> logger) : base(context, logger)
        {
        }
    }
}
