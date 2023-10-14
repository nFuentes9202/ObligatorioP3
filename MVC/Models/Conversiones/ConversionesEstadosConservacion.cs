using Dominio.Entidades;

namespace MVC.Models.Conversiones
{
    public class ConversionesEstadosConservacion
    {
        internal static IEnumerable<EstadoConservacionModel> FromLista(IEnumerable<EstadoConservacion> estadosConservacion)
        {
            var listaModels = estadosConservacion
                .Select(estados =>
                new EstadoConservacionModel
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
