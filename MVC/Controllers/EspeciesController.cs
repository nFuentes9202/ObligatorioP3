﻿using Dominio.Entidades;
using LogicaAccesoDatos.RepositoriosEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.Conversiones;

namespace MVC.Controllers
{
    public class EspeciesController : Controller
    {
        private readonly RepositorioEspecie _repoEspecie;
        private readonly RepositorioEcosistema _repoEcosistema;
        private readonly RepositorioAmenaza _repoAmenaza;
        private IWebHostEnvironment _environment;
        private readonly RepositorioEstadosConservacion _repoEstadosConservacion;
        private readonly RepositorioConfiguracion _repoConfiguracion;

        public EspeciesController(RepositorioEcosistema repoEcosistema, RepositorioEspecie repoEspecie, RepositorioAmenaza repoAmenaza, IWebHostEnvironment environment, RepositorioEstadosConservacion repoEstadosConservacion, RepositorioConfiguracion repoConfiguracion)
        {
            _repoEcosistema = repoEcosistema;
            _repoEspecie = repoEspecie;
            _repoAmenaza = repoAmenaza;
            _environment = environment;
            _repoEstadosConservacion = repoEstadosConservacion;
            _repoConfiguracion = repoConfiguracion;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            IEnumerable<AmenazaModel> amenazasModel = LlenarAmenazas();
            IEnumerable<EstadoConservacionModel> estadosModel = LlenarEstadosConservacion();
            IEnumerable<EcosistemaModel> ecosistemaModels = LlenarEcosistemas();
            SelectList amenazs = new SelectList(amenazasModel, "Id", "Descripcion");
            SelectList estados = new SelectList(estadosModel, "Id", "Nombre");
            SelectList ecosistemas = new SelectList(ecosistemaModels, "Id" ,"Nombre");

            EspecieAltaModel especieAltaModel = new EspecieAltaModel()
            {
                TodasLasAmenazas = amenazs,
                TodosLosEstadosConservacion = estados,
                TodosLosEcosistemas = ecosistemas
            };

            return View(especieAltaModel);
        }

        private IEnumerable<EcosistemaModel> LlenarEcosistemas()
        {
            IEnumerable<Ecosistema> ecosistemas = _repoEcosistema.GetAll();
            IEnumerable<EcosistemaModel> ecosistemaModel = ConversionesEcosistema.FromLista(ecosistemas);
            return ecosistemaModel;
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

        public IActionResult Create(Models.EspecieAltaModel especieAltaModel, IFormFile imagen)
        {
            try
            {
                if (especieAltaModel == null || imagen == null)
                {
                    throw new Exception("Se debe seleccionar una imagen");
                }

                if (GuardarImagen(imagen, especieAltaModel))
                {
                    var configuracionValidaciones = _repoConfiguracion.Get();

                    if (especieAltaModel.NombreVulgar.Length < configuracionValidaciones.TopeMinimoNombre || especieAltaModel.NombreVulgar.Length > configuracionValidaciones.TopeMaximoNombre)
                    {
                        throw new Exception($"El nombre debe tener entre {configuracionValidaciones.TopeMinimoNombre} y {configuracionValidaciones.TopeMaximoNombre} caracteres.");
                    }
                    if (especieAltaModel.NombreCientifico.Length < configuracionValidaciones.TopeMinimoNombre || especieAltaModel.NombreCientifico.Length > configuracionValidaciones.TopeMaximoNombre)
                    {
                        throw new Exception($"El nombre debe tener entre {configuracionValidaciones.TopeMinimoNombre} y {configuracionValidaciones.TopeMaximoNombre} caracteres.");
                    }

                    if (especieAltaModel.Descripcion.Length < configuracionValidaciones.TopeMinimoDescripcion || especieAltaModel.Descripcion.Length > configuracionValidaciones.TopeMaximoDescripcion)
                    {
                        throw new Exception($"La descripción debe tener entre {configuracionValidaciones.TopeMinimoDescripcion} y {configuracionValidaciones.TopeMaximoDescripcion} caracteres.");
                    }

                    IEnumerable<Amenaza> amenazas = _repoAmenaza.ObtenerAmenazasSegunId(especieAltaModel.AmenazasSeleccionadasIds);
                    IEnumerable<Ecosistema> ecosistemas = _repoEcosistema.ObtenerEcosistemasSegunId(especieAltaModel.EcosistemasSeleccionadosIds);
                    Especie esp = ConversionesEspecie.ModeloToEspecie(especieAltaModel);
                    esp.Amenazas = amenazas.ToList();
                    esp.Ecosistemas = ecosistemas.ToList();
                    _repoEspecie.Add(esp);
                    return View("Visualizar", especieAltaModel);
                }
                else
                {
                    throw new Exception("No se pudo crear imagen");
                }
            }
            catch (DbUpdateException excep)
            {
                TempData["Error"] = excep.InnerException.Message;
                return RedirectToAction("Create");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Create");
            }
        }
        private bool GuardarImagen(IFormFile imagen, EspecieAltaModel esp)
        {
            try
            {
                if (imagen == null || esp == null)
                {
                    throw new Exception("Es necesario subir una imagen");
                }
                // SUBIR LA IMAGEN
                //ruta física de wwwroot
                var extension = Path.GetExtension(imagen.FileName).ToLower();
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                {
                    throw new Exception("La extensión de la imagen no es válida. Solo se permiten .jpg, .jpeg y .png.");
                }
                string rutaFisicaWwwRoot = _environment.WebRootPath;

                //ruta donde se guardan las fotos de las personas
                string rutaFisicaFoto = Path.Combine
                (rutaFisicaWwwRoot, "imagenes", "especies");

                if (!Directory.Exists(rutaFisicaFoto))
                {
                    Directory.CreateDirectory(rutaFisicaFoto);
                }
                //Generamos el nombre
                int sufijo = 1;
                string nombreImagen;
                do
                {
                    nombreImagen = $"{esp.Id}_{sufijo.ToString("D3")}{extension}";
                    sufijo++;
                } while (System.IO.File.Exists(Path.Combine(rutaFisicaFoto, nombreImagen)));

                //FileStream permite manejar archivos
                try
                {
                    //el método using libera los recursos del objeto FileStream al finalizar
                    using (FileStream f = new FileStream(Path.Combine(rutaFisicaFoto, nombreImagen), FileMode.Create))
                    {
                        //Para archivos grandes o varios archivos usar la versión
                        //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                        imagen.CopyTo(f);
                    }
                    //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                    esp.ImagenRuta = nombreImagen;
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

        public IActionResult AsignarEspecie()//tecnicamente deberia funcionar pero PROBAR
        {
            /*var viewModel = new AsignarEspecieViewModel
            {
                Especies = _repoEspecie.GetAll().Select(es => new SelectListItem
                {
                    Text = es.Nombre.NombreVulgar,
                    Value = es.Id.ToString()
                }).ToList(),
                Ecosistemas = _repoEcosistema.GetAll().Select(e => new SelectListItem
                {
                    Text = e.Nombre,
                    Value = e.Id.ToString()
                }).ToList()
            };
            return View(viewModel);*/

            IEnumerable<EspecieModel> especiesModel = LlenarEspecies();
            IEnumerable<EcosistemaModel> ecosistemaModels = LlenarEcosistemas();

            SelectList especies = new SelectList(especiesModel, "Id", "Nombre");
            SelectList ecosistemas = new SelectList(ecosistemaModels, "Id", "Nombre");

            EspecieAsignarModel especieAsignarModel = new EspecieAsignarModel()
            {
                TodasLasEspecies = especies,
                TodosLosEcosistemas = ecosistemas
            };

            return View(especieAsignarModel);
        }

        private IEnumerable<EspecieModel> LlenarEspecies()//tecncicamente deberia funcionar pero PROBAR
        {
            IEnumerable<Especie> especies = _repoEspecie.GetAll();
            IEnumerable<EspecieModel> especieModel = ConversionesEspecie.FromLista(especies);
            return especieModel;
        }

        [HttpPost]
        public IActionResult AsignarEspecie(Especie especie, Ecosistema ecosistema)
        {
            try
            {
                especie= _repoEspecie.FindById(especie.Id);
                ecosistema = _repoEcosistema.FindById(ecosistema.Id);


                if(especie.Ecosistemas.Contains(ecosistema) && ecosistema.Especies.Contains(especie))
                {
                    throw new Exception("La especie ya se encuentra asignada a ese ecosistema");
                }
                else
                {
                    bool esViable = _repoEspecie.CompararAmenazas(especie, ecosistema);
                    bool esViable2 = _repoEspecie.CompararEstadosConservacion(especie, ecosistema);

                    if (esViable == true && esViable2==true)
                    {
                            especie.Ecosistemas.Add(ecosistema);
                            ecosistema.Especies.Add(especie);
                            _repoEspecie.Update(especie);
                            _repoEcosistema.Update(ecosistema);
                            return RedirectToAction("Index");
                        
                    }
                    else {                         
                        throw new Exception("La especie no puede ser asignada a ese ecosistema");
                    }
                }
            }catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AsignarEspecie");
            }
        }

        public IActionResult ConsultarEspecies()
        {
            try
            {
                IEnumerable<Especie> _especies = _repoEspecie.GetAll();//Obtener todas las especies
                var ViewModel = _especies.Select(e => new ConsultarEspeciesModel(e)).ToList(); // Convertir a ViewModel
                if (ViewModel.Count == 0)
                {
                    TempData["Error"] = "No existen registros válidos";
                }
                return View(ViewModel);
            }
            catch (Exception e)
            {

                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        /*[HttpPost]

        public IActionResult ConsultarEspecies()
        {
            return View();
        }*/
    }
}
