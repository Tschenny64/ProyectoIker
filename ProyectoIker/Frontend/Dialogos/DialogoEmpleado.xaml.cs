using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace ProyectoIker.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoEmpleado.xaml
    /// </summary>
    public partial class DialogoEmpleado : MetroWindow
    {
        private MVEmpleados _mvEmpleados;
        public DialogoEmpleado(MVEmpleados mvEmpleados)
        {
            InitializeComponent();
            _mvEmpleados = mvEmpleados;
        }

        private async void dialogoEmpleado_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _mvEmpleados.Inicializa();
                this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvEmpleados.OnErrorEvent));
                DataContext = _mvEmpleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del empleado: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }
    }
}
