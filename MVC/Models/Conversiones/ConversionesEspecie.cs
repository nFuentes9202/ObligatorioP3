using Dominio.Entidades;

namespace MVC.Models.Conversiones
{
    public class ConversionesEspecie
    {
        internal static Models.EspecieModel EspecieToEspecieModel(Especie espe)
        {
            return new Models.EspecieModel(espe);
        }

        internal static IEnumerable<EspecieModel> FromLista(IEnumerable<Especie> especies)
        {
            var listaModels = especies
                .Select(es =>
                new EspecieModel(es));

            return listaModels.ToList();
        }

        internal static Especie ModeloToEspecie(EspecieAltaModel especieAltaModel)
        {

            return new Especie
            {
                Descripcion = especieAltaModel.Descripcion,
                AtributosFisicos = new Dominio.Entidades.ValueObjects.Especie.AtributosFisicos(especieAltaModel.RangoPesoKg, especieAltaModel.RangoLongitudCm),
                Nombre = new Dominio.Entidades.ValueObjects.Especie.Nombre(especieAltaModel.NombreCientifico, especieAltaModel.NombreVulgar),
                Imagen = new Dominio.Entidades.ValueObjects.Especie.Imagen(especieAltaModel.Descripcion, especieAltaModel.NombreVulgar, especieAltaModel.ImagenRuta),
                EstadoConservacionId = especieAltaModel.EstadoConservacionId   
            };

        }




    }
}
