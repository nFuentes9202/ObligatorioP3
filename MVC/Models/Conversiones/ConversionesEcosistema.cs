using Dominio.Entidades;

namespace MVC.Models.Conversiones
{
    public class ConversionesEcosistema
    {
        internal static Models.EcosistemaModel EcosistemaToEcosistemaModel(Ecosistema ecosis)
        {
            return new Models.EcosistemaModel()
            {
                Id = ecosis.Id,
                Nombre = ecosis.Nombre,
                AreaMetrosCuadrados = ecosis.AreaMetrosCuadrados,
                Descripcion = ecosis.Descripcion,
                CoordenadasLatitud = ecosis.Coordenadas.Latitud.ToString(),
                CoordenadasLongitud = ecosis.Coordenadas.Longitud.ToString(),
                ImagenRuta = ecosis.Imagen.rutaImagen,
            };
        }
    }
}
