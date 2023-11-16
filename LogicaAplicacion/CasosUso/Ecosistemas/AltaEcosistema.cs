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
    public class AltaEcosistema : IAltaEcosistema
    {
        private readonly IRepositorioEcosistema _repoEcosistema;
        public AltaEcosistema(IRepositorioEcosistema repoEcosistema)
        {
            _repoEcosistema = repoEcosistema;
        }
        public void Alta(EcosistemaAltaDTO ecoAltaDTO)
        {
            if(ecoAltaDTO == null)
            {
                throw new EcosistemaException("No se puede dar de alta un ecosistema nulo");
            }
            Ecosistema eco = MapeoEcosistema.DTOToEcosistema(ecoAltaDTO);
            _repoEcosistema.Add(eco);

        }
    }
}
