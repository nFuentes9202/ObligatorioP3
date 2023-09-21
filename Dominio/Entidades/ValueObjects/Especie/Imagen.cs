using Dominio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.ValueObjects.Especie
{
    [Owned]
    public class Imagen
    {
        public string Descripcion { get; private set; }
        public string Nombre { get; private set; }

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

        private void Validar()
        {
            if (String.IsNullOrEmpty(Descripcion))
            {
                throw new EspecieException("La descripción no puede ser vacía");
            }
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new EspecieException("El nombre no puede ser vacío");
            }
        }
    }
}
