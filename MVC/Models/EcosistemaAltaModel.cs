using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EcosistemaAltaModel
    {
        [Required(ErrorMessage = "El nombre es necesario")]
        public string Nombre { get; set; }
        [Display(Name = "Área en metros cuadrados")]
        [Required(ErrorMessage = "El área es necesaria")]
        public double AreaMetrosCuadrados { get; set; }
        [Required(ErrorMessage = "Escriba una descripción por favor")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Escriba una latitud por favor")]
        public decimal Latitud { get; set; }
        [Required(ErrorMessage = "Escriba una longitud por favor")]
        public decimal Longitud { get; set; }
        public string? ImagenRuta { get; set; }

        [Display(Name = "Descripción de la imagen")]
        [Required(ErrorMessage = "La descripción es necesaria")]
        public string DescripcionImagen { get; set; }
        [Display(Name = "Seleccione un estado de conservación")]
        [Required(ErrorMessage = "El estado de conservación es requerido")]
        public int EstadoConservacionId { get; set; }

        public SelectList TodosLosEstadosConservacion { get; set; }

        [Display(Name = "Seleccione una amenaza")]
        [Required(ErrorMessage = "La amenaza es requerida.")]
        public IEnumerable<int> AmenazasSeleccionadasIds { get; set; }
        public SelectList TodasLasAmenazas { get; set; }

        [Display(Name = "Seleccione un país")]
        [Required(ErrorMessage = "El pais es requerido")]
        public IEnumerable<int> PaisId { get; set; }
        public SelectList TodosLosPaises { get; set; }

    }
}
