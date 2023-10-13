using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositoriosEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Entidades;
using Usuarios.ExcepcionesUsuarios;
using Usuarios.InterfacesRepositorio;

namespace LogicaAccesoDatos.RepositorioMemoria
{
    public class RepositorioUsuario: IRepositorioUsuario
    {
        private ObligatorioContext _db;
        public RepositorioUsuario(ObligatorioContext db)
        {
            _db = db;
        }
        public void Add(Usuario obj)
        {
            try
            {
                if(obj==null)
                    throw new UsuarioException("El usuario no puede ser nulo");
                obj.Validar();
                obj.Id = 0;
                _db.Usuarios.Add(obj);
                _db.SaveChanges();

            }catch(Exception ex)
            {
                throw new UsuarioException($"Error al agregar el usuario {ex.Message}", ex);
            }
        }

        public void Delete(Usuario obj)
        {
            if(obj==null)
                throw new UsuarioException("El usuario no puede ser nulo");
            try
            {
                _db.Usuarios.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UsuarioException("Error al eliminar el usuario", ex);
            }
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
            try
            {
                Usuario usuario = _db.Usuarios.FirstOrDefault(u => u.Alias == alias && u.ContraseniaSinEncriptar == password);
                if(usuario == null)
                    throw new UsuarioException("El usuario no existe");
                return usuario;
            }
            catch (Exception ex)
            {
                throw new UsuarioException("Error al buscar el usuario", ex);
            }
        }
    }
}
