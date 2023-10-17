using Dominio.Entidades;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEntity
{
    public class RepositorioPais : IRepositorioPais
    {
        private ObligatorioContext _db;
        public RepositorioPais(ObligatorioContext db)
        {
            _db = db;
        }
        public void Add(Pais obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pais obj)
        {
            throw new NotImplementedException();
        }

        public Pais FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> GetAll()
        {
            try
            {
                return _db.Paises.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Pais> ObtenerPaisesSegunId(IEnumerable<int> paisId)
        {
            return _db.Paises.Where(p => paisId.Contains(p.Id)).ToList();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}
