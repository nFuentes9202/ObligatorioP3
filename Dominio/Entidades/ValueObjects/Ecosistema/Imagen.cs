using Dominio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.ValueObjects.Ecosistema
{
    [Owned]
    public class Imagen
    {
        public Imagen()
        {
            Validar();
        }

        public Imagen(string descripcion, string nombre)
        {
            Descripcion = descripcion;
            Nombre = nombre;
            Validar();
        }

        public string Descripcion { get; private set; }
        public string Nombre { get; private set; }
        private void Validar()
        {
            if (String.IsNullOrEmpty(Descripcion))
            {
                throw new EcosistemaException("No se puede tener una descripción nula en una imagén");
            }
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new EcosistemaException("No se puede tener un nombre nulo en una imagén");
            }
        }
    }
}
