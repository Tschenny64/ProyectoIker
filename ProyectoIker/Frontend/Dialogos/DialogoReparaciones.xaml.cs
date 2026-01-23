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
    /// Interaction logic for DialogoReparaciones.xaml
    /// </summary>
    public partial class DialogoReparaciones : MetroWindow
    {
        private MVReparaciones _mvReparaciones;

        public DialogoReparaciones(MVReparaciones mvReparaciones)
        {
            InitializeComponent();
            _mvReparaciones = mvReparaciones;
        }

        private async void dialogoReparaciones_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _mvReparaciones.Inicializa();
                this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvReparaciones.OnErrorEvent));
                DataContext = _mvReparaciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la reparación: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private async void btnGuardarReparacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool exito = await _mvReparaciones.GuardarReparacionAsync();
                if (exito)
                {
                    MessageBox.Show("Reparación guardada correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Error al guardar la reparación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarReparacion_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SoloNumeros(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }
    }
}
