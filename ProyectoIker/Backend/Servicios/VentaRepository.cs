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
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        public VentaRepository(ProyectoContext context, ILogger<GenericRepository<Venta>> logger)
            : base(context, logger)
        {
        }
    }
}
