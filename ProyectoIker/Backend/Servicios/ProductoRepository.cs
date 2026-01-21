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
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {

        public ProductoRepository(ProyectoContext context, ILogger<GenericRepository<Producto>> logger)
            : base(context, logger)
        {
        }
    }
}
