using MahApps.Metro.Controls;
using ProyectoIker.Backend.Modelo;
using ProyectoIker.Backend.Servicios;
using ProyectoIker.MVM;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoIker.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoProductos.xaml
    /// </summary>
    public partial class DialogoProductos : MetroWindow
    {
        private MVProductos _mvProductos;

        public DialogoProductos(MVProductos mvProductos)
        {
            InitializeComponent();
            _mvProductos = mvProductos;
        }


        private async void dialogoProductos_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvProductos.Inicializa();
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvProductos.OnErrorEvent));
            DataContext = _mvProductos;
        }

        private async void btnGuardarProducto_Click(object sender, RoutedEventArgs e)
        {
            bool exito = await _mvProductos.GuardarProductoAsync();
            if (exito)
            {
                MessageBox.Show("Producto guardado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarProducto_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
