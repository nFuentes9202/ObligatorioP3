using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesEntidades
{
    public class PaisException : Exception
    {
        public PaisException() : base() { }
        public PaisException(string mensaje) : base(mensaje) { }
        public PaisException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}
