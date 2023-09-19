using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesEntidades
{
    public class EspecieException : Exception
    {
        public EspecieException() : base() { }
        public EspecieException(string mensaje) : base(mensaje) { }
        public EspecieException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}
