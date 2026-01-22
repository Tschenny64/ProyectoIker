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
    public class PromocioneRepository : GenericRepository<Promocione>, IPromocioneRepository
    {
        public PromocioneRepository(ProyectoContext context, ILogger<GenericRepository<Promocione>> logger) : base(context, logger)
        {
        }
    }
}
