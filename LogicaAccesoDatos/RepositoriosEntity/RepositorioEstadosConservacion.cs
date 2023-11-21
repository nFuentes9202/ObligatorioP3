using Dominio.Entidades;
using Dominio.InterfacesEntidades;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEntity
{
    public class RepositorioEstadosConservacion : IRepositorioEstadoConservacion
    {
        private ObligatorioContext _db;
        public RepositorioEstadosConservacion(ObligatorioContext db)
        {
            _db = db;
        }
        public void Add(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public EstadoConservacion FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoConservacion> GetAll()
        {
            try
            {
                return _db.EstadosConservacion.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<EstadoConservacion> IRepositorioEstadoConservacion.ObtenerEstadosConservacionSegunId(IEnumerable<int> estadosConservacionSeleccionadosIds)
        {
            return _db.EstadosConservacion.Where(e => estadosConservacionSeleccionadosIds.Contains(e.Id)).ToList();
        }
    }
}
