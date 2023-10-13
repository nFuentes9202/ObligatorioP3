using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesEntidades
{
    public interface IValidable<T> where T : class
    {
        public void Validar();
    }
}
