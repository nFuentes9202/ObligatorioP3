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

        public string Descripcion { get; }
        public string Nombre { get; }
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
