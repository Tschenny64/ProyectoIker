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
    /// Interaction logic for DialogoPromociones.xaml
    /// </summary>
    public partial class DialogoPromociones : MetroWindow
    {
        private MVPromociones _mvPromociones;

        public DialogoPromociones(MVPromociones mvPromociones)
        {
            InitializeComponent();
            _mvPromociones = mvPromociones;
        }

        private async void dialogoPromociones_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _mvPromociones.Inicializa();
                this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvPromociones.OnErrorEvent));
                DataContext = _mvPromociones;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la promoción: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private async void btnGuardarPromocion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool exito = await _mvPromociones.GuardarPromocionAsync();
                if (exito)
                {
                    MessageBox.Show("Promoción guardada correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Error al guardar la promoción", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarPromocion_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SoloNumeros(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }
    }
}
