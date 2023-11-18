using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.DTOS.Configuracion
{
    public class ConfiguracionDTO
    {
        public int Id { get; set; }
        public int TopeMinimoDescripcion { get; set; }
        public int TopeMaximoDescripcion { get; set; }
        public int TopeMinimoNombre { get; set; }
        public int TopeMaximoNombre { get; set; }
        public ConfiguracionDTO() { }
        public ConfiguracionDTO(ConfiguracionValidaciones config)
        {
            Id = config.Id;
            TopeMaximoDescripcion = config.TopeMaximoDescripcion;
            TopeMaximoNombre = config.TopeMaximoNombre;
            TopeMinimoDescripcion = config.TopeMinimoDescripcion;
            TopeMinimoNombre = config.TopeMinimoNombre;
        }
    }
}
