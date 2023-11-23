using Obligatorio.WebApi.DTOS.Ecosistemas;

namespace Obligatorio.WebApi.DTOS
{
    //Se tuvo que crear acá para poder usar IFormFile
    public class EcosistemaAltaImagenDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public double AreaMetrosCuadrados { get; set; }

        public string Descripcion { get; set; }

        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string? ImagenRuta { get; set; }
        public string? DescripcionImagen { get; set; }
        public IFormFile? Imagen { get; set; }
        public int EstadoConservacionId { get; set; }

        //public SelectList TodosLosEstadosConservacion { get; set; }
        //Ver con que reemplazarlo para uso con API
        public IEnumerable<int> AmenazasSeleccionadasIds { get; set; }
        //public SelectList TodasLasAmenazas { get; set; }

        public IEnumerable<int> PaisId { get; set; }
        //public SelectList TodosLosPaises { get; set; }

    }
}
