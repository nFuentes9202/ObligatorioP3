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
using MVC.Models.Conversiones;

namespace MVC.Controllers
{
    public class EcosistemasController : Controller
    {
        private readonly RepositorioEcosistema _repoEcosistema;

        private readonly RepositorioAmenaza _repoAmenaza;
        private IWebHostEnvironment _environment;
        private readonly RepositorioEstadosConservacion _repoEstadosConservacion;

        public EcosistemasController(RepositorioEcosistema repoEcosistema, RepositorioAmenaza repoAmenaza, IWebHostEnvironment environment, RepositorioEstadosConservacion repositorioEstadosConservacion)
        {
            _repoEcosistema = repoEcosistema;
            _repoAmenaza = repoAmenaza;
            _environment = environment;
            _repoEstadosConservacion = repositorioEstadosConservacion;
        }

        // GET: Ecosistemas
        public ActionResult Index()
        {
            IEnumerable<Ecosistema> _ecosistemas = _repoEcosistema.GetAll();
            var ViewModel = _ecosistemas.Select(e => new EcosistemaModel(e)).ToList(); // Convertir a ViewModel
            return View(ViewModel);

        }

        public IActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            IEnumerable<AmenazaModel> amenazasModel = LlenarAmenazas();
            IEnumerable<EstadoConservacionModel> estadosModel = LlenarEstadosConservacion();
            SelectList amenazs = new SelectList(amenazasModel, "Id", "Descripcion");
            SelectList estados = new SelectList(estadosModel, "Id", "Nombre");
            EcosistemaAltaModel ecosistemaAltaModel = new EcosistemaAltaModel()
            {
                TodasLasAmenazas = amenazs,
                TodosLosEstadosConservacion = estados
            };

            return View(ecosistemaAltaModel);
        }

        private IEnumerable<AmenazaModel> LlenarAmenazas()
        {
            IEnumerable<Amenaza> amenazas = _repoAmenaza.GetAll();
            IEnumerable<AmenazaModel> amenazasModel = ConversionesAmenaza.FromLista(amenazas);
            return amenazasModel;
        }
        private IEnumerable<EstadoConservacionModel> LlenarEstadosConservacion()
        {
            IEnumerable<EstadoConservacion> estados = _repoEstadosConservacion.GetAll();
            IEnumerable<EstadoConservacionModel> estadosModel = ConversionesEstadosConservacion.FromLista(estados);
            return estadosModel;
        }

        [HttpPost]

        public IActionResult Create(Models.EcosistemaAltaModel ecosistemaModel, IFormFile imagen)
        {
            try
            {
                if(ecosistemaModel == null || imagen == null)
                {
                    return RedirectToAction("Create");
                }

                if (GuardarImagen(imagen, ecosistemaModel))
                {
                    Ecosistema eco = ConversionesEcosistema.ModeloToEcosistema(ecosistemaModel);
                    _repoEcosistema.Add(eco);
                    return View("Visualizar",ecosistemaModel);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool GuardarImagen(IFormFile imagen, EcosistemaAltaModel eco)
        {
            if (imagen == null || eco == null) return false;
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _environment.WebRootPath;

            string nombreImagen = imagen.FileName;
            //ruta donde se guardan las fotos de las personas
            string rutaFisicaFoto = Path.Combine
            (rutaFisicaWwwRoot, "imagenes", "fotos", nombreImagen);
            //FileStream permite manejar archivos
            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar
                using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                {
                    //Para archivos grandes o varios archivos usar la versión
                    //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                    imagen.CopyTo(f);
                }
                //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                eco.ImagenRuta = nombreImagen;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
