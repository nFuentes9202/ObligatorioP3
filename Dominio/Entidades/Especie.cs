﻿using Dominio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Especie: IEntity, IValidable<Especie>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<Amenaza> Amenazas { get; set; }
        public List<Ecosistema> Ecosistemas { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
