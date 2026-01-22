using Org.BouncyCastle.Asn1.Mozilla;
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
            reparacione = new Reparacione();
        }

        public async Task Inicializa()
        {
            try
            {
                _listaReparaciones = await GetAllAsync<Reparacione>(_reparacioneRepository);
            } catch
            {
                
            }
        }
    }
}
