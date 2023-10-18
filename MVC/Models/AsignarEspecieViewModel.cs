using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class AsignarEspecieViewModel
    {
        public List<SelectListItem> Especies { get; set; }
        public List<SelectListItem> Ecosistemas { get; set; }
        public int EspecieId { get; set; }
        public int EcosistemaId { get; set; }
    }
}
