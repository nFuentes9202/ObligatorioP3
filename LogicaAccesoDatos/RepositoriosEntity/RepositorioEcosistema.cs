﻿using Dominio.Entidades;
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
            try
            {
                if (obj == null)
                {
                    throw new EcosistemaException("El ecosistema no puede ser nulo");
                }
                obj.Validar();
                _db.Ecosistemas.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Delete(Ecosistema obj)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int? id)
        {
            if(id == null)
            {
                throw new EcosistemaException("El id no puede ser nulo");
            }
            try
            {
                var Ecosistema = _db.Ecosistemas.Find(id);
                if (Ecosistema == null)
                {
                    return false;
                }
                _db.Ecosistemas.Remove(Ecosistema);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Ecosistema FindById(int? id)
        {
            if(id == null)
            {
                throw new EcosistemaException("El id no puede ser nulo");
            }
            Ecosistema es = _db.Ecosistemas
                .Include(es => es.Especies)
                .Include(es => es.Amenazas)
                .Include(es => es.EstadoConservacion)
                .FirstOrDefault(es => es.Id == id);

            if (es == null)
            {
                throw new EcosistemaException("No se encontró el ecosistema");
            }
            return es;
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
            if (obj == null)
            {
                throw new EcosistemaException("El ecosistema no puede ser nula");
            }
            obj.Validar();
            try
            {
                _db.Ecosistemas.Update(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el ecosistema");
            }
        }
        public bool SePuedeBorrarEcosistema(int? id)
        {
            if(id == null)
            {
                throw new EcosistemaException("El id no puede ser nulo");
            }
            var ecosistema = _db.Ecosistemas.Include(e => e.Especies).FirstOrDefault(e => e.Id == id);
            if (ecosistema.Especies.Count == 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Ecosistema> ObtenerEcosistemasSegunId(IEnumerable<int> ecosistemasSeleccionadosIds)
        {
            return _db.Ecosistemas.Where(a => ecosistemasSeleccionadosIds.Contains(a.Id)).ToList();
        }

        public IEnumerable<Ecosistema> SearchEcosistemasNoHabitables(int especieId)
        {
            // Obtener la especie seleccionada
            var especie = _db.Especies.Include(e => e.Ecosistemas).FirstOrDefault(e => e.Id == especieId);

            if (especie != null)
            {
                // Obtener todos los ecosistemas
                var ecosistemas = _db.Ecosistemas
                    .Include(ecosistema => ecosistema.Imagen)
                    .Include(ecosistema => ecosistema.Coordenadas)
                    .Include(ecosistema => ecosistema.EstadoConservacion)
                    .Include(ecosistema => ecosistema.Paises)
                    .Include(ecosistema => ecosistema.Amenazas)
                    .ToList();

                // Filtrar ecosistemas en los que la especie no puede habitar
                var ecosistemasNoHabitables = ecosistemas.Where(ecosistema => !especie.Ecosistemas.Any(e => e.Id == ecosistema.Id));

                return ecosistemasNoHabitables;
            }

            // Manejar el caso en que la especie no se encuentra
            return null;
        }

        public void Update(int id, string ruta)
        {
            if (id == null)
            {
                throw new EcosistemaException("El ecosistema no puede ser nulo");
            }
            var buscado = FindById(id);
            buscado.Validar();
            try
            {
                _db.Ecosistemas.Update(buscado);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el ecosistema");
            }
        }
    }
}
