using Dominio.Entidades;
using LogicaAplicacion.CasosUso.DTOS.Amenazas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Amenazas
{
    public interface IGetAmenazas
    {
        IEnumerable<AmenazaDTO> GetAll();
    }
}
