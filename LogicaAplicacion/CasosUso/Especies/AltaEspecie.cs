using Dominio.Entidades;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;

using LogicaAplicacion.InterfacesCasosUso.Especies;
using Obligatorio.WebApi.DTOS.Especies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaAplicacion.CasosUso.Especies
{
    public class AltaEspecie: IAltaEspecie
    {
        private readonly IRepositorioEspecie _repoEspecie;
        private readonly IRepositorioEcosistema _repoEcosistema;
        private readonly IRepositorioAmenaza _repoAmenaza;
        private readonly IRepositorioEstadoConservacion _repoEstadosConservacion;
        public AltaEspecie(IRepositorioEspecie repoEspecie, IRepositorioEcosistema repoEcosistema, IRepositorioAmenaza repoAmenaza, IRepositorioEstadoConservacion repoEstadosConservacion)
        {
            _repoEspecie = repoEspecie;
            _repoEcosistema = repoEcosistema;
            _repoAmenaza = repoAmenaza;
            _repoEstadosConservacion = repoEstadosConservacion;
        }

        public void Alta(EspecieAltaDTO espAltaDTO)
        {
            if(espAltaDTO == null)
            {
                throw new EspecieException("No se puede dar de alta un ecosistema nulo");
            }
            IEnumerable<Amenaza> amenazas = _repoAmenaza.ObtenerAmenazasSegunId(espAltaDTO.AmenazasSeleccionadasIds);
            IEnumerable<Ecosistema> ecosistemas = _repoEcosistema.ObtenerEcosistemasSegunId(espAltaDTO.EcosistemasSeleccionadosIds);
            Especie especie = MapeoEspecie.DTOToEspecie(espAltaDTO);
            especie.Amenazas = amenazas.ToList();
            especie.Ecosistemas = ecosistemas.ToList();
            _repoEspecie.Add(especie);
        }
    }
}
