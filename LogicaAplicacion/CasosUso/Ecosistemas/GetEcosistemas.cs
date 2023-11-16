using Dominio.Entidades;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosUso.Ecosistemas;
using Obligatorio.WebApi.DTOS.Ecosistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.Ecosistemas
{
    public class GetEcosistemas : IGetEcosistemas
    {
        private readonly IRepositorioEcosistema _eco;
        public GetEcosistemas(IRepositorioEcosistema eco) {
            _eco = eco;
        }
        public IEnumerable<EcosistemaListadoDTO> GetEcosistemasDTO()
        {
            var ecosistemas = _eco.GetAll();
            if(ecosistemas == null)
            {
                throw new EcosistemaException("No existen ecosistemas");
            }
            var ecosistemasDTO = MapeoEcosistema.FromLista(ecosistemas);
            return ecosistemasDTO;
        }

        public IEnumerable<EcosistemaListadoDTO> Filtrar()
        {
            throw new NotImplementedException();
        }
    }
}
