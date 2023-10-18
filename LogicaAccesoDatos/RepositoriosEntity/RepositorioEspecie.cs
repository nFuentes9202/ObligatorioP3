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

        public bool CompararAmenazas(Especie especie, Ecosistema ecosistema)
        {
            foreach (var amenaza in especie.Amenazas)//recorro las amenazas de la especie
            {
                if (!ecosistema.Amenazas.Contains(amenaza))//si el ecosistema no contiene la amenaza de la especie
                {
                    return true;//devuelvo true
                }
            }
            return false;//si recorri todas las amenazas y el ecosistema las contiene devuelvo false
        }

        public bool CompararEstadosConservacion(Especie especie, Ecosistema ecosistema)
        {
           if(especie.EstadoConservacion.RangoSeguridadMinimo > ecosistema.EstadoConservacion.RangoSeguridadMinimo)//si el rango de seguridad minimo de la especie es mayor al del ecosistema
           {
                return false;//devuelvo false
           }
            return true;
        }
    }
}
