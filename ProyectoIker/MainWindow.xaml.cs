using Microsoft.Extensions.DependencyInjection;
using ProyectoIker.Frontend.ControlUsuario;
using ProyectoIker.Frontend.Dialogos;
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

        public MainWindow(DialogoProductos dialogoProductos,
                          IServiceProvider serviceProvider,
                          UCProductos ucProductos
                            )
        {
            InitializeComponent();
            _dialogoProductos = dialogoProductos;
            _ucProductos = ucProductos;
        }

        private void btnAnyadirProducto_Click(object sender, RoutedEventArgs e)
        {
            _dialogoProductos.ShowDialog();
            _dialogoProductos = _serviceProvider.GetRequiredService<DialogoProductos>();
        }
    }
}