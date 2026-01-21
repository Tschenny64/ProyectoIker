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

namespace ProyectoIker.Frontend.ControlUsuario
{
    /// <summary>
    /// Interaction logic for UCProductos.xaml
    /// </summary>
    public partial class UCProductos : UserControl
    {
        private MVProductos _mvProductos;
        public UCProductos(MVProductos mvProductos)
        {
            InitializeComponent();
            _mvProductos = mvProductos;
        }

        private async void ucProductos_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvProductos.Inicializa();
            this.DataContext = _mvProductos;

        }
    }
}
