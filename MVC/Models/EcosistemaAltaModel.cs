using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EcosistemaAltaModel
    {
        public string Nombre { get; set; }
        public double AreaMetrosCuadrados { get; set; }
        public string Descripcion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string? ImagenRuta { get; set; }

        [Display(Name = "Descripción de la imagen")]
        public string DescripcionImagen { get; set; }
        [Display(Name = "Seleccione un estado de conservación")]
        public int EstadoConservacionId { get; set; }

        public SelectList TodosLosEstadosConservacion { get; set; }

        [Display(Name = "Seleccione una amenaza")]
        [Required(ErrorMessage = "La amenaza es requerida.")]
        public IEnumerable<int> AmenazasSeleccionadasIds { get; set; }
        public SelectList TodasLasAmenazas { get; set; }

    }
}
