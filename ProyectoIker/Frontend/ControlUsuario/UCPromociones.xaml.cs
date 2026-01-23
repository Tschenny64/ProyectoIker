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
    /// Interaction logic for UCPromociones.xaml
    /// </summary>
    public partial class UCPromociones : UserControl
    {
        private MVPromociones _mvPromociones;
        public UCPromociones(MVPromociones mvPromociones)
        {
            InitializeComponent();
            _mvPromociones = mvPromociones;
        }

        private async void ucPromociones_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvPromociones.Inicializa();
            this.DataContext = _mvPromociones;

        }
    }
}
