using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.DTOS.Paises
{
    public class ConversionesPais
    {
        internal static IEnumerable<PaisDTO> FromLista(IEnumerable<Pais> paises)
        {
            var listaModels = paises
                .Select(pais =>
                new PaisDTO
                {
                    Id = pais.Id,
                    CodigoAlpha3 = pais.CodigoAlpha3,
                    Nombre = pais.Nombre
                });
            return listaModels.ToList();
        }
    }
}
