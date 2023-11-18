using Dominio.Entidades;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.CasosUso.DTOS.Configuracion;
using LogicaAplicacion.InterfacesCasosUso.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.Configuracion
{
    public class ModificarConfiguracion : IModificarConfiguracion
    {
        private readonly IRepositorioConfiguracion _repoConfiguracion;
        public ModificarConfiguracion(IRepositorioConfiguracion repoConfiguracion) {
            _repoConfiguracion = repoConfiguracion;
        }
        public void Modificar(ConfiguracionDTO configuracionDTO)
        {
            if(configuracionDTO == null)
            {
                throw new ConfiguracionException("La configuración no puede ser nula");
            }
            ConfiguracionValidaciones configuracion = MapeoConfiguracion.DTOToConfiguracion(configuracionDTO);
            _repoConfiguracion.Update(configuracion);
        }
    }
}
