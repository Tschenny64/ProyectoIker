using ProyectoIker.Backend.Modelo;
using ProyectoIker.Backend.Servicios;
using ProyectoIker.Frontend.Mensajes;
using ProyectoIker.MVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIker.MVM
{
    public class MVProductos : MVBase
    {

        /// Objeto que guarda el modelo de producto actual
        /// Está vinculado a la vista para mostrar y editar los datos del producto
        private Producto _producto;


        /// Repositorio para gestionar las operaciones de datos relacionadas con los productos
        private ProductoRepository _productoRepository;

        /// lista de productos disponibles
        private List<Producto> _listaProductos;

        /// Getters y setters
        public List<Producto> listaProductos => _listaProductos;

        public Producto producto
        {
            get => _producto;
            set => SetProperty(ref _producto, value);
        }

        public MVProductos(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
            _producto = new Producto();
            _listaProductos = new List<Producto>();
        }


        public async Task Inicializa()
        {
            try
            {
                _listaProductos = await GetAllAsync<Producto>(_productoRepository);
            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("GESTION PRODUCTOS", "Error al cargar los productos\n" +
                    "No puedo conectar con la base de datos", 0);
            }
        }

        public async Task<bool> GuardarProductoAsync()
        {
            bool correcto = true;
            try
            {
                if (producto.CodigoUnico == 0)
                {
                    // Nuevo producto
                    correcto = await AddAsync<Producto>(_productoRepository, producto);
                }
                else
                {
                    // Actualizar producto existente
                    correcto = await UpdateAsync<Producto>(_productoRepository, producto);
                }
                if (correcto)
                {
                    await Inicializa(); // Refrescar la lista de productos
                }
            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("GESTION PRODUCTOS", "Error al guardar el producto\n" +
                    "No puedo conectar con la base de datos", 0);
                correcto = false;
            }
            return correcto;
        }
    }
}
