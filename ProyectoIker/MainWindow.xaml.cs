using Microsoft.Extensions.DependencyInjection;
using ProyectoIker.Frontend.ControlUsuario;
using ProyectoIker.Frontend.Dialogos;
using ProyectoIker.MVM;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoIker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DialogoProductos _dialogoProductos;
        private readonly IServiceProvider _serviceProvider;
        private UCProductos _ucProductos;
        private UCEmpleados _ucEmpleados;
        private UCReparaciones _ucReparaciones;
        private UCPromociones _ucPromociones;
        private DialogoEmpleados _dialogoEmpleados;
        private DialogoPromociones _dialogoPromociones;
        private DialogoReparaciones _dialogoReparaciones;

        public MainWindow(DialogoProductos dialogoProductos,
                          IServiceProvider serviceProvider,
                          UCProductos ucProductos,
                          UCEmpleados ucEmpleados,
                          UCReparaciones ucReparaciones,
                          UCPromociones ucPromociones,
                          DialogoEmpleados dialogoEmpleados,
                          DialogoPromociones dialogoPromociones,
                          DialogoReparaciones dialogoReparaciones
                            )
        {
            InitializeComponent();
            _dialogoProductos = dialogoProductos;
            _ucProductos = ucProductos;
            _ucEmpleados = ucEmpleados;
            _serviceProvider = serviceProvider;
            _ucReparaciones = ucReparaciones;
            _ucPromociones = ucPromociones;
            _dialogoEmpleados = dialogoEmpleados;
            _dialogoPromociones = dialogoPromociones;
            _dialogoReparaciones = dialogoReparaciones;
        }

        private void btnAnyadirProducto_Click(object sender, RoutedEventArgs e)
        {
            _dialogoProductos.ShowDialog();
            _dialogoProductos = _serviceProvider.GetRequiredService<DialogoProductos>();
        }

        private void btnAnyadirEmpleado_Click(object sender, RoutedEventArgs e)
        {
            _dialogoEmpleados.ShowDialog();
            _dialogoEmpleados = _serviceProvider.GetRequiredService<DialogoEmpleados>();
        }

        private void btnAnyadirPromocion_Click(object sender, RoutedEventArgs e)
        {
            _dialogoPromociones.ShowDialog();
            _dialogoPromociones = _serviceProvider.GetRequiredService<DialogoPromociones>();
        }

        private void btnAnyadirReparacion_Click(object sender, RoutedEventArgs e)
        {
            _dialogoReparaciones.ShowDialog();
            _dialogoReparaciones = _serviceProvider.GetRequiredService<DialogoReparaciones>();
        }

        private async void UCEmpleados_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(_ucEmpleados);

            if (_ucEmpleados.DataContext is MVEmpleados vm)
                await vm.Inicializa();
        }

        private void UCProductos_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(_ucProductos);
        }

        private void UCReparaciones_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(_ucReparaciones);
        }

        private void UCPromociones_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(_ucPromociones);
        }
    }
}