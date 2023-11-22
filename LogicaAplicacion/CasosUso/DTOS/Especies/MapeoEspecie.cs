using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Obligatorio.WebApi.DTOS.Ecosistemas;

namespace Obligatorio.WebApi.DTOS.Especies
{
    public class MapeoEspecie
    {
        internal static Especie DTOToEspecie(EspecieAltaDTO ecpecieAltaModel)
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

        internal static EspecieListadoDTO EspecieToEspecieDTO(Especie especie)
        {
            return new EspecieListadoDTO(especie);
        }
    }
}
