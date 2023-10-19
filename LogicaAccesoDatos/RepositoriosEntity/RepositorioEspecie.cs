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
            Especie es = _db.Especies
                .Include(e => e.Ecosistemas)
                .Include(e => e.Amenazas)
                .Include(e => e.EstadoConservacion)
                .FirstOrDefault(e => e.Id == id);

            if (es == null)
            {
                throw new EcosistemaException("No se encontró la especie");
            }
            return es;
        }

        public IEnumerable<Especie> GetAll()
        {
            try
            {
                return _db.Especies
                    .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.EstadoConservacion)
                    .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.Imagen)

                    .Include(e => e.Amenazas)
                    .Include(e => e.AtributosFisicos)
                    .Include(e => e.Imagen)
                    .Include(e => e.Nombre)
                    .Include(e => e.EstadoConservacion)
                    .ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Especie obj)
        {
            if(obj == null)
            {
                throw new EspecieException("La especie no puede ser nula");
            }
            obj.Validar();
            try
            {
                _db.Especies.Update(obj);
                _db.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception("No se pudo modificar la especie");
            }
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

        public IEnumerable<Especie> SearchByNombreCientifico(string nombreCientifico)
        {
            return _db.Especies.Where(e => e.Nombre.NombreCientifico.Contains(nombreCientifico))
                                    .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.EstadoConservacion)
                    .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.Imagen)
                    .Include(e => e.Amenazas)
                    .Include(e => e.AtributosFisicos)
                    .Include(e => e.Imagen)
                    .Include(e => e.Nombre)
                    .Include(e => e.EstadoConservacion)
                .ToList();
        }

        public IEnumerable<Especie> SearchByPeligroExtincion()
        {
            var especiesEnPeligro = _db.Especies
                .Where(e =>
                    e.EstadoConservacion.RangoSeguridadMaximo < 60 ||
                    e.Amenazas.Count > 3 ||
                    e.Ecosistemas.Any(ecosistema =>
                        ecosistema.Amenazas.Count > 3 &&
                        ecosistema.EstadoConservacion.RangoSeguridadMaximo < 60))
                    .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.EstadoConservacion)
                    .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.Imagen)
                    .Include(e => e.Amenazas)
                    .Include(e => e.AtributosFisicos)
                    .Include(e => e.Imagen)
                    .Include(e => e.Nombre)
                    .Include(e => e.EstadoConservacion)
                .ToList();

            return especiesEnPeligro;
        }

        public IEnumerable<Especie> SearchByPesoRange(decimal pesoMinimo, decimal pesoMaximo)
        {
            return _db.Especies
                .Where(e => e.AtributosFisicos.RangoPesoKg >= pesoMinimo && e.AtributosFisicos.RangoPesoKg <= pesoMaximo)
                     .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.EstadoConservacion)
                    .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.Imagen)
                    .Include(e => e.Amenazas)
                    .Include(e => e.AtributosFisicos)
                    .Include(e => e.Imagen)
                    .Include(e => e.Nombre)
                    .Include(e => e.EstadoConservacion)
                .ToList();
        }

        public IEnumerable<Especie> SearchByEcosistema(int ecosistemaId)
        {
            return _db.Especies
                .Where(e => e.Ecosistemas.Any(ecosistema => ecosistema.Id == ecosistemaId))
                    .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.EstadoConservacion)
                    .Include(e => e.Ecosistemas)
                    .ThenInclude(ecosistema => ecosistema.Imagen)
                    .Include(e => e.Amenazas)
                    .Include(e => e.AtributosFisicos)
                    .Include(e => e.Imagen)
                    .Include(e => e.Nombre)
                    .Include(e => e.EstadoConservacion)
                .ToList();
        }

        /*public IEnumerable<Ecosistema> SearchEcosistemasNoHabitables(int especieId)
        {
            // Obtener la especie seleccionada
            var especie = _db.Especies.Include(e => e.Ecosistemas).FirstOrDefault(e => e.Id == especieId);

            if (especie != null)
            {
                // Obtener todos los ecosistemas y filtrar aquellos en los que la especie no puede habitar
                var ecosistemas = _db.Ecosistemas.ToList();
                var ecosistemasNoHabitables = ecosistemas.Where(ecosistema => !especie.Ecosistemas.Any(e => e.Id == ecosistema.Id))
                    .Include(ecosistemas.);

                return ecosistemasNoHabitables;
            }

            // Manejar el caso en que la especie no se encuentra
            return null;
        }*/

    }
}
