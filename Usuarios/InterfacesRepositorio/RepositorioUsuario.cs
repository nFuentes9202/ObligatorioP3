using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Entidades;

namespace Usuarios.InterfacesRepositorio
{
    public class RepositorioUsuario : IRepositorio<Usuario>
    {
        public void Add(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string alias, string password)
        {
            throw new NotImplementedException();
        }
    }
}
