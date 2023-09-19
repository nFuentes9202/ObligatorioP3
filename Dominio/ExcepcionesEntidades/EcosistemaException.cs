using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesEntidades
{
    public class EcosistemaException : Exception
    {
        public EcosistemaException() : base() { }
        public EcosistemaException(string mensaje) : base(mensaje) { }
        public EcosistemaException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}
