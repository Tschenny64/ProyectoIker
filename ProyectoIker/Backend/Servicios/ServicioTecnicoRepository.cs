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
    public class ServicioTecnicoRepository : GenericRepository<ServiciosTecnico>, IGenericRepository<ServiciosTecnico>
    {
        public ServicioTecnicoRepository(ProyectoContext context, ILogger<GenericRepository<ServiciosTecnico>> logger)
            : base(context, logger)
        {
        }
    }
}
