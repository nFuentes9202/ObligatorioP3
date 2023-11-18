using Dominio.Entidades;
using Obligatorio.WebApi.DTOS.Ecosistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.DTOS.Configuracion
{
    public class MapeoConfiguracion
    {
        internal static ConfiguracionDTO ConfiguracionAConfiguracionDTO(ConfiguracionValidaciones config)
        {
            return new ConfiguracionDTO(config);
        }

        internal static ConfiguracionValidaciones DTOToConfiguracion(ConfiguracionDTO config)
        {
            return new ConfiguracionValidaciones
            {
                Id = config.Id,
                TopeMaximoDescripcion = config.TopeMaximoDescripcion,
                TopeMaximoNombre = config.TopeMaximoNombre,
                TopeMinimoDescripcion = config.TopeMinimoDescripcion,
                TopeMinimoNombre = config.TopeMinimoNombre,

        };

        }
    }
}

