using Dominio.Entidades;
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
        public static Especie DTOToEspecie(EspecieAltaDTO ecpecieAltaModel)
        {
            return new Especie
            {
                Descripcion = ecpecieAltaModel.Descripcion,
                Nombre = new Dominio.Entidades.ValueObjects.Especie.Nombre(ecpecieAltaModel.NombreVulgar, ecpecieAltaModel.NombreCientifico),
                AtributosFisicos = new Dominio.Entidades.ValueObjects.Especie.AtributosFisicos(ecpecieAltaModel.RangoLongitudCm, ecpecieAltaModel.RangoPesoKg),
                Imagen = new Dominio.Entidades.ValueObjects.Especie.Imagen(ecpecieAltaModel.DescripcionImagen, ecpecieAltaModel.NombreVulgar, ecpecieAltaModel.ImagenRuta),
                EstadoConservacionId = ecpecieAltaModel.EstadoConservacionId
            };

        }
    }
}
