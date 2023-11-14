using Dominio.Entidades;

namespace Obligatorio.WebApi.DTOS.Ecosistemas
{
    public class EcosistemaListadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double AreaMetrosCuadrados { get; set; }
        public string Descripcion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string? ImagenRuta { get; set; }
        public string DescripcionImagen { get; set; }
        public string EstadoConservacionNombre { get; set; }

        public EcosistemaListadoDTO(Ecosistema ecosistema)
        {
            Id = ecosistema.Id;
            Nombre = ecosistema.Nombre;
            AreaMetrosCuadrados = ecosistema.AreaMetrosCuadrados;
            Descripcion = ecosistema.Descripcion;
            ImagenRuta = ecosistema.Imagen?.RutaImagen;
            DescripcionImagen = ecosistema.Imagen?.Descripcion;
            Latitud = ecosistema.Coordenadas?.Latitud ?? 0;
            Longitud = ecosistema.Coordenadas?.Longitud ?? 0;
            EstadoConservacionNombre = ecosistema.EstadoConservacion?.Nombre ?? "Desconocido";
        }
    }
}
