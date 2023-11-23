using LogicaAplicacion.CasosUso.DTOS.Usuarios;
using Obligatorio.WebApi.DTOS.Ecosistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Entidades;

namespace LogicaAplicacion.InterfacesCasosUso.Usuarios
{
    // TODO Agregar items a interfaz
    public interface IAltaUsuario
    {
        public void Alta(UsuarioDTO usuarioDTO);

    }
}
