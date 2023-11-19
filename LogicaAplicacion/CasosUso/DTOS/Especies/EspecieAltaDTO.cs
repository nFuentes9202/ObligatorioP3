using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogicaAplicacion.CasosUso.DTOS.Especies
{
    public class EspecieAltaDTO
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

        [Display(Name = "Descripción de la imagen")]
        [Required(ErrorMessage = "La descripción es necesaria")]
        public string DescripcionImagen { get; set; }
        [Display(Name = "Seleccione un estado de conservación")]
        [Required(ErrorMessage = "El estado de conservación es requerido")]
        public int EstadoConservacionId { get; set; }


        [Display(Name = "Seleccione una o varias amenaza")]
        [Required(ErrorMessage = "La amenaza es requerida.")]
        public IEnumerable<int> AmenazasSeleccionadasIds { get; set; }

        [Display(Name = "Seleccione uno o varios ecosistemas")]
        [Required(ErrorMessage = "Los ecosistemas son requeridos")]
        public IEnumerable<int> EcosistemasSeleccionadosIds { get; set; }

    }
}
