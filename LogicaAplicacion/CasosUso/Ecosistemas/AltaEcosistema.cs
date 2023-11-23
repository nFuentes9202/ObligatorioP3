using Dominio.Entidades;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;

using LogicaAplicacion.CasosUso.DTOS.Amenazas;
using LogicaAplicacion.CasosUso.DTOS.EstadosConservacion;
using LogicaAplicacion.CasosUso.DTOS.Paises;
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
        private readonly IRepositorioPais _repoPaises;
        private readonly IRepositorioAmenaza _repoAmenaza;
        private readonly IRepositorioEstadoConservacion _repoEstadosConservacion;
        public AltaEcosistema(IRepositorioEcosistema repoEcosistema, IRepositorioPais repoPaises, IRepositorioAmenaza repoAmenaza, IRepositorioEstadoConservacion repoEstadosConservacion)
        {
            _repoEcosistema = repoEcosistema;
            _repoPaises = repoPaises;
            _repoAmenaza = repoAmenaza;
            _repoEstadosConservacion = repoEstadosConservacion;
        }
        public void Alta(EcosistemaAltaDTO ecoAltaDTO)
        {
            if(ecoAltaDTO == null)
            {
                throw new EcosistemaException("No se puede dar de alta un ecosistema nulo");
            }
            IEnumerable<Amenaza> amenazas = _repoAmenaza.ObtenerAmenazasSegunId(ecoAltaDTO.AmenazasSeleccionadasIds);
            IEnumerable<Pais> paises = _repoPaises.ObtenerPaisesSegunId(ecoAltaDTO.PaisId);
            Ecosistema eco = MapeoEcosistema.DTOToEcosistema(ecoAltaDTO);
            eco.Amenazas = amenazas.ToList();
            eco.Paises = paises.ToList();
            _repoEcosistema.Add(eco);

        }

        //TODO Estos metodos son para mostrar en el get, ups
        private IEnumerable<PaisDTO> LlenarPaises()
        {
            IEnumerable<Pais> paises = _repoPaises.GetAll();
            IEnumerable<PaisDTO> paisesDTO = ConversionesPais.FromLista(paises);
            return paisesDTO;
        }

        private IEnumerable<AmenazaDTO> LlenarAmenazas()
        {
            IEnumerable<Amenaza> amenazas = _repoAmenaza.GetAll();
            IEnumerable<AmenazaDTO> amenazasDTO = ConversionesAmenaza.FromLista(amenazas);
            return amenazasDTO;
        }
        private IEnumerable<EstadoConservacionDTO> LlenarEstadosConservacion()
        {
            IEnumerable<EstadoConservacion> estados = _repoEstadosConservacion.GetAll();
            IEnumerable<EstadoConservacionDTO> estadosDTO = ConversionesEstadosConservacion.FromLista(estados);
            return estadosDTO;
        }
    }
}
