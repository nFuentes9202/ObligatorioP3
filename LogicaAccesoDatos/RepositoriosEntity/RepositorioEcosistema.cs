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
    public class RepositorioEcosistema : IRepositorioEcosistema
    {
        private ObligatorioContext _db = new ObligatorioContext();
        public void Add(Ecosistema obj)
        {
            if (obj == null)
            {
                throw new EcosistemaException("El ecosistema no puede ser nulo");
            }
            obj.Validar();
            _db.Ecosistemas.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(Ecosistema obj)
        {
            throw new NotImplementedException();
        }

        public Ecosistema FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ecosistema> GetAll()
        {
            return _db.Ecosistemas.ToList();
        }

        public void Update(Ecosistema obj)
        {
            throw new NotImplementedException();
        }
    }
}
