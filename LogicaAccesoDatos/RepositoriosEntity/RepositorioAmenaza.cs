using Dominio.Entidades;
using Dominio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEntity
{
    public class RepositorioAmenaza : IRepositorioAmenaza
    {
        private ObligatorioContext _db;
        public RepositorioAmenaza(ObligatorioContext db)
        {
            _db = db;
        }
        public void Add(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public Amenaza FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Amenaza> GetAll()
        {
            try
            {
                return _db.Amenazas.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Amenaza obj)
        {
            throw new NotImplementedException();
        }
    }
}
