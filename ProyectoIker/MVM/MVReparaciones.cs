using ProyectoIker.Backend.Modelo;
using ProyectoIker.Backend.Servicios;
using ProyectoIker.Frontend.Mensajes;
using ProyectoIker.MVM.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoIker.MVM
{
    public class MVReparaciones : MVBase
    {
        private ReparacioneRepository _reparacioneRepository;
        private List<Reparacione> _listaReparaciones;

        private Reparacione _reparacione;
        public Reparacione reparacione
        {
            get => _reparacione;
            set => SetProperty(ref _reparacione, value);
        }

        public List<Reparacione> listaReparaciones => _listaReparaciones;

        public MVReparaciones(ReparacioneRepository reparacioneRepository)
        {
            _reparacioneRepository = reparacioneRepository;
            _reparacione = new Reparacione();
            _listaReparaciones = new List<Reparacione>();
        }

        public async Task Inicializa()
        {
            try
            {
                _listaReparaciones = await GetAllAsync<Reparacione>(_reparacioneRepository);
            }
            catch
            {
                MensajeError.Mostrar(
                    "GESTIÓN REPARACIONES",
                    "Error al cargar las reparaciones\nNo puedo conectar con la base de datos",
                    0);
            }
        }

        public async Task<bool> GuardarReparacionAsync()
        {
            bool correcto = true;
            try
            {
                // CAMBIA "CodigoUnico" por la PK real de Reparacione (IdReparacion, CodigoReparacion, etc.)
                if (reparacione.Id == 0)
                {
                    correcto = await AddAsync<Reparacione>(_reparacioneRepository, reparacione);
                }
                else
                {
                    correcto = await UpdateAsync<Reparacione>(_reparacioneRepository, reparacione);
                }

                if (correcto)
                {
                    await Inicializa();
                }
            }
            catch
            {
                MensajeError.Mostrar(
                    "GESTIÓN REPARACIONES",
                    "Error al guardar la reparación\nNo puedo conectar con la base de datos",
                    0);
                correcto = false;
            }

            return correcto;
        }
    }
}
