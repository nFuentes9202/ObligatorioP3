using LogicaAplicacion.CasosUso.DTOS.Usuarios;
using LogicaAplicacion.InterfacesCasosUso.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Entidades;
using Usuarios.InterfacesRepositorio;

namespace LogicaAplicacion.CasosUso.Usuarios
{
    public class AltaUsuario : IAltaUsuario
    {
        private readonly RepositorioUsuario _repoUsu;

        public AltaUsuario(RepositorioUsuario repoUsu)
        {
            _repoUsu = repoUsu;
        }

        public void Alta(UsuarioDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }
      

    }
}
