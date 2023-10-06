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
        RepositorioEcosistema _repoEcosistema = new RepositorioEcosistema();

        // GET: Ecosistemas
        public ActionResult Index()
        {
            IEnumerable<Ecosistema> _ecosistemas = _repoEcosistema.GetAll();
            return View(_ecosistemas);

        }
    }
}
