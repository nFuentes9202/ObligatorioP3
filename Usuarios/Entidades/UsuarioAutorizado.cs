using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.InterfacesEntidades;

namespace Usuarios.Entidades
{
    public class UsuarioAutorizado : Usuario, IValidable<UsuarioAutorizado>
    {
        public UsuarioAutorizado() { }
        public UsuarioAutorizado(string alias, string contraseniasinencriptar) : base(alias, contraseniasinencriptar)
        {
        }

    }
}
