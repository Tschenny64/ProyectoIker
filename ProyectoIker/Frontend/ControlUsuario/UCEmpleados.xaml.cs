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
    /// Interaction logic for UCEmpleados.xaml
    /// </summary>
    public partial class UCEmpleados : UserControl
    {
        private MVEmpleados _mvEmpleados;
        public UCEmpleados(MVEmpleados mvEmpleado)
        {
            InitializeComponent();
            _mvEmpleados = mvEmpleado;
        }

        private async void ucEmpleados_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _mvEmpleados;
            await _mvEmpleados.Inicializa();
        }
    }
}
