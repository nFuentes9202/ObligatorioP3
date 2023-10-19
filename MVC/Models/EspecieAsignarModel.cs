using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EspecieAsignarModel
    {

        [Display(Name = "Especie")]
        [Required(ErrorMessage = "Seleccione una especie")]
        public int EspecieId { get; set; }

        [Display(Name = "Ecosistema")]
        [Required(ErrorMessage = "Seleccione un ecosistema")]
        public int EcosistemaId { get; set; }

        public List<SelectListItem> Especies { get; set; }
        public List<SelectListItem> Ecosistemas { get; set; }


    }
}

