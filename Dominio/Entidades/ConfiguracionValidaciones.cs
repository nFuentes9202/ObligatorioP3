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
        public int TopeMinimoDescripcion { get; set; }
        public int TopeMaximoDescripcion { get; set; }
        public int TopeMinimoNombre { get; set; }
        public int TopeMaximoNombre { get; set; }

        public ConfiguracionValidaciones()
        {
        }

        public void ActualizarTopeMinimoDescripcion(int nuevoTope, int longitudActualMinimaDescripcion)
        {
            if (nuevoTope < 0 || nuevoTope > TopeMaximoDescripcion || nuevoTope > longitudActualMinimaDescripcion)
            {
                throw new LimiteTextoException("El nuevo tope mínimo para la descripción es inválido o hay registros que no cumplen con el nuevo tope.");
            }

            TopeMinimoDescripcion = nuevoTope;
        }

        public void ActualizarTopeMaximoDescripcion(int nuevoTope, int longitudActualMaximaDescripcion)
        {
            if (nuevoTope < TopeMinimoDescripcion || nuevoTope < longitudActualMaximaDescripcion)
            {
                throw new LimiteTextoException("El nuevo tope máximo para la descripción no puede ser menor que el tope mínimo o hay registros que no cumplen con el nuevo tope.");
            }

            TopeMaximoDescripcion = nuevoTope;
        }

        public void ActualizarTopeMinimoNombre(int nuevoTope, int longitudActualMinimaNombre)
        {
            if (nuevoTope < 0 || nuevoTope > TopeMaximoNombre || nuevoTope > longitudActualMinimaNombre)
            {
                throw new LimiteTextoException("El nuevo tope mínimo para el nombre es inválido o hay registros que no cumplen con el nuevo tope.");
            }

            TopeMinimoNombre = nuevoTope;
        }

        public void ActualizarTopeMaximoNombre(int nuevoTope, int longitudActualMaximaNombre)
        {
            if (nuevoTope < TopeMinimoNombre || nuevoTope < longitudActualMaximaNombre)
            {
                throw new LimiteTextoException("El nuevo tope máximo para el nombre no puede ser menor que el tope mínimo o hay registros que no cumplen con el nuevo tope.");
            }

            TopeMaximoNombre = nuevoTope;
        }
    }
}
