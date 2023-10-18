using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EspecieAsignarModel
    {

        [Display(Name = "Seleccione una especie")]
        [Required(ErrorMessage = "La especie es requerida.")]
        public IEnumerable<int> EspeciesSeleccionadasIds { get; set; }
        public SelectList TodasLasEspecies { get; set; }


        [Display(Name = "Seleccione un ecosistema")]
        [Required(ErrorMessage = "El ecosistema es requeridos")]
        public IEnumerable<int> EcosistemasSeleccionadosIds { get; set; }
        public SelectList TodosLosEcosistemas { get; set; }

    }
}

