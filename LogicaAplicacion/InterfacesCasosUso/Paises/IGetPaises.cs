using Dominio.Entidades;
using LogicaAplicacion.CasosUso.DTOS.Paises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Paises
{
    public interface IGetPaises
    {
        IEnumerable<PaisDTO> GetAll();
    }
}
