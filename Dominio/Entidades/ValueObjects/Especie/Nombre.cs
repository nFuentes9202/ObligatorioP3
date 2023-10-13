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
    public class Nombre
    {
        public string NombreCientifico { get; private set; }
        public string NombreVulgar { get; private set; }

        public Nombre()
        {
            Validar();
        }

        public Nombre(string nombreCientifico, string nombreVulgar)
        {
            NombreCientifico = nombreCientifico;
            NombreVulgar = nombreVulgar;
            Validar();
        }

        private void Validar()
        {
            if(String.IsNullOrEmpty(NombreCientifico))
            {
                throw new EspecieException("El nombre científico no puede ser vacío");
            }
            if (String.IsNullOrEmpty(NombreVulgar))
            {
                throw new EspecieException("El nombre científico no puede ser vacío");
            }
        }
    }
}
