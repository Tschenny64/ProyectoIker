using Castle.Core.Logging;
using ProyectoIker.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProyectoIker.Backend.Servicios;
using Microsoft.Extensions.Logging;


namespace ProyectoIker.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ProyectoContext _contexto;
        private EmpleadoRepository _empleadoRepository;
        private ILogger<GenericRepository<Empleado>> _logger;
        public Login()
        {
            InitializeComponent();
            _contexto = new ProyectoContext();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Password.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _logger = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger<GenericRepository<Empleado>>();

            _empleadoRepository = new EmpleadoRepository(_contexto, _logger);

            if (await _empleadoRepository.LoginAsync(txtUsuario.Text, txtPassword.Password))
            {
                // si la autenticacion es correcta, abrimos la ventana principal
                //pasando el usuario logueado
                Window mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        private void ventanaLogin_Loaded(object sender, RoutedEventArgs e)
        {
            //instanciamos el contexto y el repositorio de usuarios
            //el contexto nos permite conectar con la base de datos
            _contexto = new ProyectoContext();
            // El logger nos permite registrar eventos y errores
            // crear un logger para el repositorio genérico de usuarios
            _logger = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger<GenericRepository<Empleado>>();
            _empleadoRepository = new EmpleadoRepository(_contexto, _logger);
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
