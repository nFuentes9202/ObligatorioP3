using Dominio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Amenaza:IEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int GradoPeligrosidad { get; set; }
    }
}
