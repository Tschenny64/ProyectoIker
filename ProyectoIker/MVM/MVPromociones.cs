using Microsoft.EntityFrameworkCore.Query;
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
    public class MVPromociones : MVBase
    {
        private Promocione _promocion;

        private PromocioneRepository _promocioneRepository;

        private List<Promocione> _listaPromociones;

        public List<Promocione> listaPromociones => _listaPromociones;

        public Promocione promocion
        {
            get => _promocion;
            set => SetProperty(ref _promocion, value);
        }

        public MVPromociones(PromocioneRepository promocioneRepository)
        {
            _promocioneRepository = promocioneRepository;
            _promocion = new Promocione();
            _listaPromociones = new List<Promocione>();
        }

        public async Task Inicializa()
        {
            try
            {
                _listaPromociones = await GetAllAsync<Promocione>(_promocioneRepository);
            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("GESTION PROMOCIONES", "Error al cargar las promociones\n" +
                    "No puedo conectar con la base de datos", 0);
            }
        }

    }
}
