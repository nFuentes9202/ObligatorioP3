using Dominio.InterfacesRepositorio;
using LogicaAplicacion.CasosUso.DTOS.Amenazas;
using LogicaAplicacion.InterfacesCasosUso.Amenazas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.Amenazas
{
    public class GetAmenazas : IGetAmenazas
    {
        private readonly IRepositorioAmenaza _amenazas;

        public GetAmenazas(IRepositorioAmenaza amenazas)
        {
            _amenazas = amenazas;
        }

        public IEnumerable<AmenazaDTO> GetAll()
        {
            var amenazas = _amenazas.GetAll();
            var amenazasDTO = ConversionesAmenaza.FromLista(amenazas);
            return amenazasDTO;
        }
    }
}
