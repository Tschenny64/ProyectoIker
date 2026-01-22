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
using MahApps.Metro.Controls;


namespace ProyectoIker.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly MainWindow _mainWindow;
        public Login(EmpleadoRepository empleadoRepository,
                     MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _empleadoRepository = empleadoRepository;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(passClave.Password))
            {
                //Añadimos el accesoPermitido para poder validar el usuario y la contraseña
                //y solo si esta en la base de datos podrá iniciar sesion
                // Validación directa usando los controles txtUsuario y passClave
                bool accesoPermitido = await _empleadoRepository.LoginAsync(txtUsuario.Text, passClave.Password);
                //Tambien añadimos este if
                if (accesoPermitido)
                {
                    _mainWindow.Show();
                    this.Close();
                }

                //y añadimos el else en el caso de que no este en la bbdd
                else
                {
                    MessageBox.Show("Por favor introduce usuario y clave.", "Error de autenticación",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Por favor introduce usuario y clave.", "Error de autenticación",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
