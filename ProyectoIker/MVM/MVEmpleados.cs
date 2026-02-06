using ProyectoIker.Backend.Modelo;
using ProyectoIker.Backend.Servicios;
using ProyectoIker.Frontend.Mensajes;
using ProyectoIker.MVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        public List<Empleado> listaEmpleados
        {
            get => _listaEmpleados;
            set => SetProperty(ref _listaEmpleados, value);
        }
        public async Task<bool> GuardarEmpleadoAsync()
        {
            bool correcto = true;
            try
            {
                // Asignar FK y evitar insertar Role
                empleado.RolId = empleado.Rol?.Id;
                empleado.Rol = null; // CLAVE: evita Duplicate entry en roles

                if (empleado.CodigoUnico == 0)
                {
                    correcto = await AddAsync<Empleado>(_empleadoRepository, empleado);
                }
                else
                {
                    correcto = await UpdateAsync<Empleado>(_empleadoRepository, empleado);
                }

                if (correcto)
                    await Inicializa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR al guardar empleado");
                correcto = false;
            }

            return correcto;
        }



        public async Task Inicializa()
        {
            try
            {
                listaEmpleados = await GetAllAsync<Empleado>(_empleadoRepository);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR al listar empleados");
                listaEmpleados = new List<Empleado>();
            }

            try
            {
                Roles = await GetAllAsync<Role>(_roleRepository);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                Roles = new List<Role>();
            }

        }


    }
}