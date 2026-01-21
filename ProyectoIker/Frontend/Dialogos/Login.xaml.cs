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
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly MainWindow _mainWindow;
        public Login()
        {
            InitializeComponent();
        }
        public Login(EmpleadoRepository empleadoRepository,
                     MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _empleadoRepository = empleadoRepository;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(passClave.Password))
            {
                bool accesoPermitido = await _empleadoRepository.LoginAsync(txtUsuario.Text, passClave.Password);
                if (accesoPermitido)
                {
                    _mainWindow.Show();
                    this.Close();
                }
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
