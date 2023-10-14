using Dominio.Entidades.ValueObjects.Especie;
using Dominio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ConfiguracionValidaciones
    {
        public int Id { get; set; }
        public int topeMinimoDescripcion {  get; private set; }
        public int topeMaximoDescripcion { get; private set; }
        public int topeMinimoNombre{ get; private set; }
        public int topeMaximoNombre { get; private set; }

        public ConfiguracionValidaciones()
        {
        }
        public void ActualizarTopeMinimoDescripcion(int nuevoTope)
        {
            if (nuevoTope < topeMinimoDescripcion)
            {
                throw new LimiteTextoException("El nuevo tope mínimo para la descripción no puede ser menor que el tope actual.");
            }

            topeMinimoDescripcion = nuevoTope;
        }

        public void ActualizarTopeMinimoNombre(int nuevoTope)
        {
            if (nuevoTope < topeMinimoNombre)
            {
                throw new LimiteTextoException("El nuevo tope mínimo para el nombre no puede ser menor que el tope actual.");
            }

            topeMinimoNombre = nuevoTope;
        }
        public void ValidarDatos(string nombre, string descripcion)
        {
            if(nombre.Length < topeMinimoDescripcion)
            {
                throw new LimiteTextoException($"El nombre no puede ser menor a {topeMinimoNombre}");
            }
            if(nombre.Length >  topeMaximoDescripcion)
            {
                throw new LimiteTextoException($"El nombre no puede ser mayor a {topeMaximoNombre}");
            }
            if (descripcion.Length < topeMinimoDescripcion)
            {
                throw new LimiteTextoException($"La descripcion no puede ser menor a {topeMinimoDescripcion}");
            }
            if (descripcion.Length > topeMaximoDescripcion)
            {
                throw new LimiteTextoException($"La descripcion no puede ser mayor a {topeMaximoDescripcion}");
            }
        }
    }
}
