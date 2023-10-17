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

        //me parece que va a servir el subsistema solo para UsuarioAdminController y de ahi hacer los create UsuarioAutorizado
        //pero no me termina de convencer
    }
}