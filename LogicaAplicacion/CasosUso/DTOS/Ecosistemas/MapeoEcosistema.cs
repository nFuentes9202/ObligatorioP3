using Dominio.Entidades;

namespace Obligatorio.WebApi.DTOS.Ecosistemas
{
    public class MapeoEcosistema
    {
        internal static EcosistemaListadoDTO EcosistemaToEcosistemaDTO(Ecosistema ecosis)
        {
            return new EcosistemaListadoDTO(ecosis);
        }

        internal static IEnumerable<EcosistemaListadoDTO> FromLista(IEnumerable<Ecosistema> ecosistemas)
        {
            var listaModels = ecosistemas
                .Select(ecos =>
                new EcosistemaListadoDTO(ecos));

            return listaModels.ToList();
        }

        internal static Ecosistema DTOToEcosistema(EcosistemaAltaDTO ecosistemaAltaModel)
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
