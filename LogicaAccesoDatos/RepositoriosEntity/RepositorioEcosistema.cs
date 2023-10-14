using Dominio.Entidades;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEntity
{
    public class RepositorioEcosistema : IRepositorioEcosistema
    {
        private ObligatorioContext _db;
        public RepositorioEcosistema(ObligatorioContext db)
        {
            _db = db;
        }

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
            try
            {
                return _db.Ecosistemas
                                       .Include(e => e.EstadoConservacion)
                                       .ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Update(Ecosistema obj)
        {
            throw new NotImplementedException();
        }
        
    }
}
