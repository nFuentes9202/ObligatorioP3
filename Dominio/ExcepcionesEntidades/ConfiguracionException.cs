using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesEntidades
{
    public class ConfiguracionException: Exception
    {
        public ConfiguracionException() : base() { }
        public ConfiguracionException(string mensaje) : base(mensaje) { }
        public ConfiguracionException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}
