using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class EspeciesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
