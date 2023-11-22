using Dominio.InterfacesRepositorio;
using LogicaAplicacion.CasosUso.DTOS.Paises;
using LogicaAplicacion.InterfacesCasosUso.Paises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.Paises
{
    public class GetPaises : IGetPaises
    {
        private readonly IRepositorioPais _paises;

        public GetPaises(IRepositorioPais paises)
        {
            _paises = paises;
        }
        public IEnumerable<PaisDTO> GetAll()
        {
            var paises = _paises.GetAll();

            var paisesDTO = ConversionesPais.FromLista(paises);

            return paisesDTO;
        }
    }
}
