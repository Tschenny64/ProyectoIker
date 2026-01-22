using Microsoft.Extensions.Logging;
using ProyectoIker.Backend.Modelo;
using ProyectoIker.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIker.Backend.Servicios
{
    public class TiposEquipoRepository : GenericRepository<TiposEquipo>, ITiposEquipoRepository
    {
        public TiposEquipoRepository(ProyectoContext context, ILogger<GenericRepository<TiposEquipo>> logger)
            : base(context, logger)
        {
        }
    }
}
