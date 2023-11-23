using Obligatorio.WebApi.DTOS.Ecosistemas;

namespace Obligatorio.WebApi.DTOS.ConversionesDTO
{
    public class MapeosEco
    {
        public static EcosistemaAltaDTO conversion(EcosistemaAltaImagenDTO eco)
        {
            return new EcosistemaAltaDTO
            {
                Id = eco.Id,
                Nombre = eco.Nombre,
                AreaMetrosCuadrados = eco.AreaMetrosCuadrados,
                Descripcion = eco.Descripcion,
                Latitud = eco.Latitud,
                Longitud = eco.Longitud,
                ImagenRuta = eco.ImagenRuta,
                DescripcionImagen = eco.DescripcionImagen,

                EstadoConservacionId = eco.EstadoConservacionId,
                AmenazasSeleccionadasIds = eco.AmenazasSeleccionadasIds,
                PaisId = eco.PaisId
            };
        }
    }
}
