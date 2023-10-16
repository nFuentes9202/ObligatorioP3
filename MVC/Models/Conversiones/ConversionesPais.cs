using Dominio.Entidades;

namespace MVC.Models.Conversiones
{
    public class ConversionesPais
    {
        internal static IEnumerable<PaisModel> FromLista(IEnumerable<Pais> paises)
        {
            var listaModels = paises
                .Select(pais =>
                new PaisModel
                {
                    Id = pais.Id,
                    CodigoAlpha3 = pais.CodigoAlpha3,
                    Nombre = pais.Nombre
                });
            return listaModels.ToList();
        }
    }
}
