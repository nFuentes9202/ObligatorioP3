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
    public class GetEcosistemaById : IGetEcosistemaById
    {
        private IRepositorioEcosistema _repoEco;
        public GetEcosistemaById(IRepositorioEcosistema repoEco)
        {
            _repoEco = repoEco;
        }
        public EcosistemaListadoDTO GetEcosistema(int? id)
        {
            if (id == null)
            {
                throw new EcosistemaException("Ingrese el id del ecosistema a buscar");
            }
            Ecosistema eco = _repoEco.FindById(id.Value);

            EcosistemaListadoDTO ecosistemaDTO = eco!=null? MapeoEcosistema.EcosistemaToEcosistemaDTO(eco):null;

            return ecosistemaDTO;
                
        }
    }
}
