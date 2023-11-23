using Obligatorio.WebApi.DTOS.Ecosistemas;
using Obligatorio.WebApi.DTOS.Especies;

namespace Obligatorio.WebApi.DTOS.ConversionesDTO
{
    public class MapeosEspecie
    {
        public static EspecieAltaDTO conversion(EspecieAltaImagenDTO especie)
        {
            return new EspecieAltaDTO
            {
                Id = especie.Id,
                Descripcion = especie.Descripcion,
                NombreCientifico = especie.NombreCientifico,
                NombreVulgar = especie.NombreVulgar,
                RangoPesoKg = especie.RangoPesoKg,
                RangoLongitudCm = especie.RangoLongitudCm,
                ImagenRuta = especie.ImagenRuta,
                DescripcionImagen = especie.DescripcionImagen,

                EstadoConservacionId = especie.EstadoConservacionId,
                AmenazasSeleccionadasIds = especie.AmenazasSeleccionadasIds,
                EcosistemasSeleccionadosIds = especie.EcosistemasSeleccionadosIds
            };
        }
    }
}
