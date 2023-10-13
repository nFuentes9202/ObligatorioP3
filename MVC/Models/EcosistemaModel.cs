using Dominio.Entidades;

namespace MVC.Models
{
    public class EcosistemaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double AreaMetrosCuadrados { get; set; }
        public string Descripcion { get; set; }
        public List<Especie> Especies { get; set; }
        public List<Pais> Paises { get; set; }
        public List<Amenaza> Amenazas { get; set; }
        public string CoordenadasLatitud { get; set; }
        public string CoordenadasLongitud { get; set; }
        public string? ImagenRuta { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
        public int EstadoConservacionId { get; set; }

    }
}
