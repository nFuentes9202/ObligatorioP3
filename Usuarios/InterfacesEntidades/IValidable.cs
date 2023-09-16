using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.InterfacesEntidades
{
    internal interface IValidable<T> where T : class
    {
        void Validar();
    }
}
