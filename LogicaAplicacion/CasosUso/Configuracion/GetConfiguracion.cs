using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.CasosUso.DTOS.Configuracion;
using LogicaAplicacion.InterfacesCasosUso.Configuracion;
using Obligatorio.WebApi.DTOS.Ecosistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.Configuracion
{
    public class GetConfiguracion : IGetConfiguracion
    {
        private readonly IRepositorioConfiguracion _repo;

        public GetConfiguracion(IRepositorioConfiguracion repo)
        {
            _repo = repo;
        }

        public ConfiguracionDTO GetConfiguracionPrimera()
        {
            var configuracion = _repo.Get();

            var configuracionDTO = MapeoConfiguracion.ConfiguracionAConfiguracionDTO(configuracion);
            return configuracionDTO;
        }
    }
}
