using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesEntidades
{
    public class EstadoConservacionException : Exception
    {
        public EstadoConservacionException() : base() { }
        public EstadoConservacionException(string mensaje) : base(mensaje) { }
        public EstadoConservacionException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}
