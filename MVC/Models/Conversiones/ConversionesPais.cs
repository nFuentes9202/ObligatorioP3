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

        internal static Pais PaisAltaModelAPais(PaisAltaModel paisAltaModel)
        {
            return new Pais
            {
                Id = paisAltaModel.Id,
                CodigoAlpha3 = paisAltaModel.CodigoAlpha3,
                Nombre = paisAltaModel.CommonName
            };
        }
    }
}
