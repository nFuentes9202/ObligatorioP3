using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using LogicaAccesoDatos.RepositoriosEntity;
using MVC.Models;

namespace MVC.Controllers
{
    public class EcosistemasController : Controller
    {
        private readonly RepositorioEcosistema _repoEcosistema;

        public EcosistemasController(RepositorioEcosistema repoEcosistema)
        {
            _repoEcosistema = repoEcosistema;
        }

        // GET: Ecosistemas
        public ActionResult Index()
        {
            IEnumerable<Ecosistema> _ecosistemas = _repoEcosistema.GetAll();
            var ViewModel = _ecosistemas.Select(e => new EcosistemaModel(e)).ToList(); // Convertir a ViewModel
            return View(ViewModel);

        }
    }
}
