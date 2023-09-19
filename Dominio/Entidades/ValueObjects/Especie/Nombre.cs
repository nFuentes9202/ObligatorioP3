using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.ValueObjects.Especie
{
    [Owned]
    public class Nombre
    {
        public string NombreCientifico { get; }
        public string NombreVulgar { get; }
    }
}
