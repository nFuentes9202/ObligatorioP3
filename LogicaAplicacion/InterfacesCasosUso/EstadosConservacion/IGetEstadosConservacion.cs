using Dominio.Entidades;
using LogicaAplicacion.CasosUso.DTOS.EstadosConservacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.EstadosConservacion
{
    public interface IGetEstadosConservacion
    {
        IEnumerable<EstadoConservacionDTO> GetAll();
    }
}
