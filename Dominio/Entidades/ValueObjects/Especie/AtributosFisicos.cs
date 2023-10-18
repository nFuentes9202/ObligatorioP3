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
    public class AtributosFisicos
    {
        public decimal RangoPesoKg { get; private set; }
        public decimal RangoLongitudCm { get; private set; }

        public AtributosFisicos()
        {
        }

        public AtributosFisicos(decimal rangoPesoKg, decimal rangoLongitudCm)
        {
            RangoPesoKg = rangoPesoKg;
            RangoLongitudCm = rangoLongitudCm;
            Validar();
        }

        private void Validar()
        {
            if (RangoPesoKg <= 0)
            {
                throw new EspecieException("Las magnitudes deben ser positivas");
            }
            if(RangoLongitudCm <= 0)
            {
                throw new EspecieException("Las magnitudes deben ser positivas");
            }
        }
    }
}
