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
        private ProyectoContext _contexto;
        private IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
            _contexto = new ProyectoContext();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ProyectoContext>();
            services.AddLogging(static configure => configure.AddConsole());
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<MainWindow>();

            services.AddScoped<IGenericRepository<Producto>, ProductoRepository>();

            services.AddScoped<ProductoRepository>();

            services.AddTransient<Login>();

            services.AddTransient<UCProductos>();

            services.AddTransient<MVProductos>();

    }
    }

}
