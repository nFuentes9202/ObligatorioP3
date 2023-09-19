﻿using Dominio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Amenaza:IEntity, IValidable<Amenaza>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int GradoPeligrosidad { get; set; }
        public List<Ecosistema> Ecosistemas { get; set; }
        public List<Especie> Especies { get; set; }
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
