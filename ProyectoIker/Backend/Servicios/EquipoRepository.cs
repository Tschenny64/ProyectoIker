using Microsoft.Extensions.Logging;
using ProyectoIker.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIker.Backend.Servicios
{
    public class EquipoRepository : GenericRepository<Equipo>, IEquipoRepository
    {
        public EquipoRepository(ProyectoContext context, ILogger<GenericRepository<Equipo>> logger) : base(context, logger)
        {
        }
    }
}
