using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProyectoIker.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIker.Backend.Servicios
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
        {
        public RoleRepository(ProyectoContext context, ILogger<GenericRepository<Role>> logger) : base(context, logger)
        {
        }
        }
    }

    