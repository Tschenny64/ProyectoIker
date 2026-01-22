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
    public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(ProyectoContext context, ILogger<GenericRepository<Marca>> logger) 
            : base(context, logger)
        {
        }
    }
}
