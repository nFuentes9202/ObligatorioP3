using Dominio.Entidades;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEntity
{
    public class RepositorioEspecie : IRepositorioEspecie
    {
        private ObligatorioContext _db;
        public RepositorioEspecie(ObligatorioContext db)
        {
            _db = db;
        }
        public void Add(Especie obj)
        {
            try
            {
                if (obj == null)
                {
                    throw new EcosistemaException("La especie no puede ser nula");
                }
                obj.Validar();
                _db.Especies.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Especie obj)
        {
            throw new NotImplementedException();
        }

        public Especie FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Especie> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Especie obj)
        {
            throw new NotImplementedException();
        }
    }
}
