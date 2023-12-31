﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioEstadoConservacion:IRepositorio<EstadoConservacion>
    {
        public IEnumerable<EstadoConservacion> ObtenerEstadosConservacionSegunId(IEnumerable<int> estadosConservacionSeleccionadosIds);
    }
}
