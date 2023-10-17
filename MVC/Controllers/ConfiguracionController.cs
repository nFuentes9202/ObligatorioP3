using Dominio.Entidades;
using LogicaAccesoDatos.RepositoriosEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ConfiguracionController : Controller
    {
        private RepositorioConfiguracion _repoConfiguracion;

        public ConfiguracionController(RepositorioConfiguracion repoConfiguracion)
        {
            _repoConfiguracion = repoConfiguracion;
        }


        // GET: ConfiguracionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConfiguracionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConfiguracionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfiguracionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConfiguracionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConfiguracionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConfiguracionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConfiguracionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult EditarTopes()
        {
            var configuracion = _repoConfiguracion.Get();
            return View(configuracion);
        }

        [HttpPost]
        public IActionResult GuardarTopes(ConfiguracionValidaciones configuracion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repoConfiguracion.Update(configuracion);
                    TempData["Feedback"] = "¡Se edita satisfactoriamente la configuracion!";
                    return RedirectToAction("EditarTopes"); // o donde quieras redirigir después de guardar
                }
                return View("EditarTopes", configuracion);
            }
            catch (Exception e)
            {

                TempData["Feedback"] = e.Message;
                return RedirectToAction("EditarTopes");
            }
            
        }
    }
}
