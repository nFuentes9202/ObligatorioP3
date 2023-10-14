using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesEntidades
{
    public class LimiteTextoException:Exception
    {
        public LimiteTextoException() : base() { }
        public LimiteTextoException(string mensaje) : base(mensaje) { }
        public LimiteTextoException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}
