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
using Microsoft.Data.SqlClient;

namespace MVC.Controllers
{
    public class EcosistemasController : Controller
    {
        private readonly RepositorioEcosistema _repoEcosistema;

        private readonly RepositorioAmenaza _repoAmenaza;
        private IWebHostEnvironment _environment;
        private readonly RepositorioEstadosConservacion _repoEstadosConservacion;
        private readonly RepositorioPais _repoPaises;

        public EcosistemasController(RepositorioEcosistema repoEcosistema, RepositorioAmenaza repoAmenaza, IWebHostEnvironment environment, RepositorioEstadosConservacion repositorioEstadosConservacion, RepositorioPais repoPais)
        {
            _repoEcosistema = repoEcosistema;
            _repoAmenaza = repoAmenaza;
            _environment = environment;
            _repoEstadosConservacion = repositorioEstadosConservacion;
            _repoPaises = repoPais;
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
            IEnumerable<PaisModel> paisesModel = LlenarPaises();
            SelectList amenazs = new SelectList(amenazasModel, "Id", "Descripcion");
            SelectList estados = new SelectList(estadosModel, "Id", "Nombre");
            SelectList paises = new SelectList(paisesModel, "Id", "Nombre");
            EcosistemaAltaModel ecosistemaAltaModel = new EcosistemaAltaModel()
            {
                TodasLasAmenazas = amenazs,
                TodosLosEstadosConservacion = estados,
                TodosLosPaises = paises
            };

            return View(ecosistemaAltaModel);
        }

        private IEnumerable<PaisModel> LlenarPaises()
        {
            IEnumerable<Pais> paises = _repoPaises.GetAll();
            IEnumerable<PaisModel> paisesModel = ConversionesPais.FromLista(paises);
            return paisesModel;
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
                    IEnumerable<Amenaza> amenazas = _repoAmenaza.ObtenerAmenazasSegunId(ecosistemaModel.AmenazasSeleccionadasIds);
                    IEnumerable<Pais> paises = _repoPaises.ObtenerPaisesSegunId(ecosistemaModel.PaisId);
                    Ecosistema eco = ConversionesEcosistema.ModeloToEcosistema(ecosistemaModel);
                    eco.Amenazas = amenazas.ToList();
                    eco.Paises = paises.ToList();
                    _repoEcosistema.Add(eco);
                    return View("Visualizar",ecosistemaModel);
                }
                return RedirectToAction("Index");
            }
            catch(DbUpdateException excep)
            {
                TempData["Error"] = excep.InnerException.Message;
                return RedirectToAction("Create");
            }
            catch (Exception e)
            {
                Type tipoExcepcion = e.GetType();
                TempData["Error"] = e.Message;
                return RedirectToAction("Create");
            }
        }
        private bool GuardarImagen(IFormFile imagen, EcosistemaAltaModel eco)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
            
        }

        public IActionResult Borrar(int id)
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") == null)
                {
                    return Unauthorized(); // No autorizado
                }

                if (_repoEcosistema.SePuedeBorrarEcosistema(id))
                {
                    _repoEcosistema.Delete(id);
                    TempData["Feedback"] = "¡Ecosistema borrado exitosamente!";
                }
                else
                {
                    // Si el ecosistema es habitado, redirige con un mensaje de error
                    TempData["Feedback"] = "El ecosistema no puede ser borrado porque es habitado por especies.";

                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
