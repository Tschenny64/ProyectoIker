using ProyectoIker.Backend.Modelo;
using ProyectoIker.Backend.Servicios;
using ProyectoIker.Frontend.Mensajes;
using ProyectoIker.MVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIker.MVM
{
    public class MVEmpleados : MVBase
    {
        private Empleado _empleado;

        private EmpleadoRepository _empleadoRepository;
        private RoleRepository _roleRepository;

        private List<Empleado> _listaEmpleados;

        public Empleado empleado
        {
            get => _empleado;
            set => SetProperty(ref _empleado, value);
        }

        private List<Role> _roles;
        public List<Role> Roles
        {
            get => _roles;
            set => SetProperty(ref _roles, value);
        }

        public MVEmpleados(EmpleadoRepository empleadoRepository, RoleRepository roleRepository)
        {
            _empleadoRepository = empleadoRepository;
            _roleRepository = roleRepository;
            _empleado = new Empleado();
        }


        public List<Empleado> listaEmpleados => _listaEmpleados;

        public async Task<bool> GuardarEmpleadoAsync()
        {
            bool correcto = true;
            try
            {
                // OJO: cambia "CodigoUnico" por la PK real de Empleado (IdEmpleado, CodigoEmpleado, etc.)
                if (empleado.CodigoUnico == 0)
                {
                    // Nuevo empleado
                    correcto = await AddAsync<Empleado>(_empleadoRepository, empleado);
                }
                else
                {
                    // Actualizar empleado existente
                    correcto = await UpdateAsync<Empleado>(_empleadoRepository, empleado);
                }

                if (correcto)
                {
                    await Inicializa(); // refrescar lista
                }
            }
            catch
            {
                MensajeError.Mostrar(
                    "GESTIÓN EMPLEADOS",
                    "Error al guardar el empleado\nNo puedo conectar con la base de datos",
                    0);
                correcto = false;
            }

            return correcto;
        }


        public async Task Inicializa()
        {
            try
            {
                _listaEmpleados = await GetAllAsync<Empleado>(_empleadoRepository);
                Roles = await GetAllAsync<Role>(_roleRepository);
            }
            catch
            {
                MensajeError.Mostrar(
                  "GESTIÓN USUARIOS",
                  "Error al cargar datos de usuario",
                  0);
            }

        }


    }
}
