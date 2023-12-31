﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioEspecie: IRepositorio<Especie>
    {
        void Update(int id, string ruta);

        int GetIdByUnique(string unique);

    }
}
