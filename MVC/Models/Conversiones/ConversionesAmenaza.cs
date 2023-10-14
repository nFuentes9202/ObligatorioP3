using Dominio.Entidades;

namespace MVC.Models.Conversiones
{
    public class ConversionesAmenaza
    {
        internal static IEnumerable<AmenazaModel> FromLista(IEnumerable<Amenaza> amenazas)
        {
            var listaModels = amenazas
                .Select(amen =>
                new AmenazaModel
                {
                    Id = amen.Id,
                    Descripcion = amen.Descripcion,
                    GradoPeligrosidad = amen.GradoPeligrosidad
                });
            return listaModels.ToList();
        }
    }
}
