using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.DTOS.Amenazas
{
    public class AmenazaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int GradoPeligrosidad { get; set; }
    }
}
