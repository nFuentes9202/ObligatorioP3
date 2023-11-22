using Dominio.InterfacesRepositorio;
using LogicaAplicacion.CasosUso.DTOS.EstadosConservacion;
using LogicaAplicacion.InterfacesCasosUso.EstadosConservacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.EstadosConservacion
{
    public class GetEstadosConservacion : IGetEstadosConservacion
    {
        private readonly IRepositorioEstadoConservacion _estadosConservacion;

        public GetEstadosConservacion(IRepositorioEstadoConservacion estadosConservacion)
        {
            _estadosConservacion = estadosConservacion;
        }
        public IEnumerable<EstadoConservacionDTO> GetAll()
        {
            var estados = _estadosConservacion.GetAll();
            var estadosDTO = ConversionesEstadosConservacion.FromLista(estados);
            return estadosDTO;
        }
    }
}
