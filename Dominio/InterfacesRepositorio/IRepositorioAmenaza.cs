﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioAmenaza: IRepositorio<Amenaza>
    {
        public IEnumerable<Amenaza> ObtenerAmenazasSegunId(IEnumerable<int> amenazasSeleccionadasIds);
    }
}
