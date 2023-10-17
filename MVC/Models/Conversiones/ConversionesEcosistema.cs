using Dominio.Entidades;

namespace MVC.Models.Conversiones
{
    public class ConversionesEcosistema
    {
        internal static Models.EcosistemaModel EcosistemaToEcosistemaModel(Ecosistema ecosis)
        {
            return new Models.EcosistemaModel(ecosis);
        }

        internal static IEnumerable<EcosistemaModel> FromLista(IEnumerable<Ecosistema> ecosistemas)
        {
            var listaModels = ecosistemas
                .Select(ecos =>
                new EcosistemaModel(ecos));
    
            return listaModels.ToList();
        }

        internal static Ecosistema ModeloToEcosistema(EcosistemaAltaModel ecosistemaAltaModel)
        {
            return new Ecosistema
            {
                Nombre = ecosistemaAltaModel.Nombre,
                AreaMetrosCuadrados = ecosistemaAltaModel.AreaMetrosCuadrados,
                Descripcion = ecosistemaAltaModel.Descripcion,
                Coordenadas = new Dominio.Entidades.ValueObjects.Ecosistema.Coordenadas(ecosistemaAltaModel.Latitud, ecosistemaAltaModel.Longitud),
                Imagen = new Dominio.Entidades.ValueObjects.Ecosistema.Imagen(ecosistemaAltaModel.Descripcion, ecosistemaAltaModel.Nombre, ecosistemaAltaModel.ImagenRuta),
                EstadoConservacionId = ecosistemaAltaModel.EstadoConservacionId
            };

        }
    }
}
