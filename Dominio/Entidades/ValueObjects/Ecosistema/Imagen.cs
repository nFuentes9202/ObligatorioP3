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
        }

        public Imagen(string descripcion, string nombre, string rutaImagen)
        {
            Descripcion = descripcion;
            Nombre = nombre;
            RutaImagen = rutaImagen;
            Validar();
        }

        public string Descripcion { get; private set; }
        public string Nombre { get; private set; }

        public string RutaImagen { get; set; }
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
