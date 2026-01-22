using ProyectoIker.MVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for UCReparaciones.xaml
    /// </summary>
    public partial class UCReparaciones : UserControl
    {
        private MVReparaciones _mvReparaciones;
        public UCReparaciones(MVReparaciones mvReparaciones)
        {
            InitializeComponent();
            _mvReparaciones = mvReparaciones;
        }

        private async void ucReparaciones_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvReparaciones.Inicializa();
            this.DataContext = _mvReparaciones;

        }
    }
}
