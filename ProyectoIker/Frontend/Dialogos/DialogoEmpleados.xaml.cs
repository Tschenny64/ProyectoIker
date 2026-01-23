using MahApps.Metro.Controls;
using ProyectoIker.MVM;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProyectoIker.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoEmpleados.xaml
    /// </summary>
    public partial class DialogoEmpleados : MetroWindow
    {
        private MVEmpleados _mvEmpleados;

        public DialogoEmpleados(MVEmpleados mvEmpleados)
        {
            InitializeComponent();
            _mvEmpleados = mvEmpleados;
        }

        private async void dialogoEmpleados_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _mvEmpleados.Inicializa();
                this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvEmpleados.OnErrorEvent));
                DataContext = _mvEmpleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del empleado: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private async void btnGuardarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _mvEmpleados.empleado.Password = txtPassword.Password;
                bool exito = await _mvEmpleados.GuardarEmpleadoAsync();
                if (exito)
                {
                    MessageBox.Show("Empleado guardado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Error al guardar el empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnCancelarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SoloNumeros(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }
    }
}
