using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.DTOS.Amenazas
{
    public class ConversionesAmenaza
    {
        internal static IEnumerable<AmenazaDTO> FromLista(IEnumerable<Amenaza> amenazas)
        {
            var listaModels = amenazas
                .Select(amen =>
                new AmenazaDTO
                {
                    Id = amen.Id,
                    Descripcion = amen.Descripcion,
                    GradoPeligrosidad = amen.GradoPeligrosidad
                });
            return listaModels.ToList();
        }
    }
}
