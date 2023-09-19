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
        public string Descripcion { get; }
        public string Nombre { get; }
    }
}
