using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.DTOS.EstadosConservacion
{
    public class EstadoConservacionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RangoSeguridadMinimo { get; set; }
        public int RangoSeguridadMaximo { get; set; }
    }
}
