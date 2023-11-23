using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EspecieAltaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La descripción es necesaria")]
        public string Descripcion { get; set; }
        
        [Display(Name = "Nombre Científico")]
        [Required(ErrorMessage = "El nombre científico es necesario")]
        public string NombreCientifico { get; set; }

        [Display(Name = "Nombre Vulgar")]
        [Required(ErrorMessage = "El nombre vulgar es necesario")]
        public string NombreVulgar { get; set; }

        [Display(Name = "Rango de peso en Kg")]
        [Required(ErrorMessage = "Escriba el peso por favor")]
        public decimal RangoPesoKg { get; set; }
        [Display(Name = "Rango de longitud en Cm")]
        [Required(ErrorMessage = "Escriba una longitud por favor")]
        public decimal RangoLongitudCm { get; set; }
        public string? ImagenRuta { get; set; }

        [Required(ErrorMessage = "Debe subir una imagen para la foto")]
        [Display(Name = "Foto")]
        public IFormFile? Imagen { get; set; }

        [Display(Name = "Descripción de la imagen")]
        [Required(ErrorMessage = "La descripción es necesaria")]
        public string? DescripcionImagen { get; set; }
        [Display(Name = "Seleccione un estado de conservación")]
        [Required(ErrorMessage = "El estado de conservación es requerido")]
        public int EstadoConservacionId { get; set; }

        public SelectList TodosLosEstadosConservacion { get; set; }

        [Display(Name = "Seleccione una o varias amenaza")]
        [Required(ErrorMessage = "La amenaza es requerida.")]
        public IEnumerable<int> AmenazasSeleccionadasIds { get; set; }
        public SelectList TodasLasAmenazas { get; set; }

        [Display(Name = "Seleccione uno o varios ecosistemas")]
        [Required(ErrorMessage = "Los ecosistemas son requeridos")]
        public IEnumerable<int> EcosistemasSeleccionadosIds { get; set; }
        public SelectList TodosLosEcosistemas { get; set; }

    }
}
