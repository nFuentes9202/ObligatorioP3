using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.DTOS.EstadosConservacion
{
    public class ConversionesEstadosConservacion
    {
        public static IEnumerable<EstadoConservacionDTO> FromLista(IEnumerable<EstadoConservacion> estadosConservacion)
        {
            var listaModels = estadosConservacion
                .Select(estados =>
                new EstadoConservacionDTO
                {
                    Id = estados.Id,
                    Nombre = estados.Nombre,
                    RangoSeguridadMaximo = estados.RangoSeguridadMaximo,
                    RangoSeguridadMinimo = estados.RangoSeguridadMinimo
                });
            return listaModels.ToList();
        }
    }
}
