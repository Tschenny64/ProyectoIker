using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProyectoIker.Backend.Modelo;
using ProyectoIker.Backend.Servicios;
using ProyectoIker.Frontend.ControlUsuario;
using ProyectoIker.Frontend.Dialogos;
using ProyectoIker.MVM;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ProyectoIker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ProyectoContext _context;
        private IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
            _context = new ProyectoContext();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ProyectoContext>();
            services.AddLogging(static configure => configure.AddConsole());
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<MainWindow>();


            services.AddScoped<IGenericRepository<Producto>, ProductoRepository>();
            services.AddScoped<IGenericRepository<Empleado>, EmpleadoRepository>();
            services.AddScoped<IGenericRepository<Reparacione>, ReparacioneRepository>();

            services.AddScoped<ProductoRepository>();
            services.AddScoped<EmpleadoRepository>();
            services.AddScoped<ReparacioneRepository>();

            services.AddTransient<Login>();

            services.AddTransient<UCProductos>();
            services.AddTransient<UCEmpleados>();
            services.AddTransient<UCReparaciones>();
            services.AddTransient<DialogoProductos>();

            services.AddTransient<MVProductos>();
            services.AddTransient<MVEmpleados>();
            services.AddTransient<MVReparaciones>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Se genera la ventana de Login
            //esto es como un new
            var loginWindow = _serviceProvider.GetService<Login>();
            loginWindow.Show();
            base.OnStartup(e);
        }
    }

}
