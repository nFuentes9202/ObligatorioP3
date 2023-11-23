using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Entidades;

namespace Usuarios.InterfacesRepositorio
{
    public interface RepositorioUsuario : IRepositorio<Usuario>
    {
        public void Add(Usuario obj);


        public void Delete(Usuario obj);


        public Usuario FindById(int? id);


        public IEnumerable<Usuario> GetAll();


        public void Update(Usuario obj);


        public Usuario Login(string alias, string password)
        ;

        public bool AliasExiste(string alias);
    }
}
