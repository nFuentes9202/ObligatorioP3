using Dominio.Entidades;

namespace MVC.Models.Conversiones
{
    public class ConversionesEspecie
    {
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
