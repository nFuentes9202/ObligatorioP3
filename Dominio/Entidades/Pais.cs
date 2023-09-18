﻿using Dominio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pais: IEntity, IValidable
    {
        public int Id { get; set; }
        public string CodigoAlpha3 { get; set; }
        public int Nombre { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
        
    }
}