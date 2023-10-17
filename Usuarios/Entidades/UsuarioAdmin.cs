using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.InterfacesEntidades;

namespace Usuarios.Entidades
{
    public class UsuarioAdmin : Usuario, IValidable<UsuarioAdmin>
    {
        public UsuarioAdmin() { }
        public UsuarioAdmin(string alias, string contraseniaencriptada, string contraseniasinencriptar) : base(alias, contraseniasinencriptar)
        {
        }
    }
}