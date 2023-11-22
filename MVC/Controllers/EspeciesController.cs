using Dominio.Entidades;
using LogicaAccesoDatos.RepositoriosEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.Conversiones;
using System.Text.Json;

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

        private static HttpClient _cli = new HttpClient();//Cliente http para hacer las peticiones al web api

        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions()//Opciones para el serializador de json
        {
            PropertyNameCaseInsensitive = true,//Ignorar mayúsculas y minúsculas
            WriteIndented = true//Dar formato al json
        };

        public EspeciesController(RepositorioEcosistema repoEcosistema, RepositorioEspecie repoEspecie, RepositorioAmenaza repoAmenaza, IWebHostEnvironment environment, RepositorioEstadosConservacion repoEstadosConservacion, RepositorioConfiguracion repoConfiguracion)
        {
            if(_cli.BaseAddress == null)//Si la dirección base del cliente es nula
            {
                _cli.BaseAddress = new Uri("https://localhost:44374/api/Especie");//Asignar la dirección base
            }

            _cli.DefaultRequestHeaders.Accept.Clear();//Limpiar los headers
            _cli.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//Agregar el header de json

            _repoEcosistema = repoEcosistema;
            _repoEspecie = repoEspecie;
            _repoAmenaza = repoAmenaza;
            _environment = environment;
            _repoEstadosConservacion = repoEstadosConservacion;
            _repoConfiguracion = repoConfiguracion;
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult Create()
        {
            /*IEnumerable<AmenazaModel> amenazasModel = LlenarAmenazas();
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
            };*/
            var especieAltaModel = new EspecieAltaModel();
            try
            {
                CargarListaDesplegables(especieAltaModel);
            }catch(Exception)
            {
                ViewData["Error"] = "Problemas al cargar las listas desplegables";
            }

            return View(especieAltaModel);
        }

        private void CargarListaDesplegables(EspecieAltaModel especieAltaModel)
        {
            try
            {
                IEnumerable<AmenazaModel> listaAmenazas = new List<AmenazaModel>();
                IEnumerable<EstadoConservacionModel> listaEstadosConservacion = new List<EstadoConservacionModel>();
                IEnumerable<EcosistemaModel> listaEcosistemas = new List<EcosistemaModel>();

                //Cargar amenazas
                var responseAmenazas = _cli.GetAsync(new Uri(_cli.BaseAddress, "amenazas"));//Obtener la respuesta de la petición
                responseAmenazas.Wait();//Esperar a que termine la petición
                var resultAmenazas = responseAmenazas.Result;//Obtener el resultado de la petición
                if (resultAmenazas.IsSuccessStatusCode)//Si la petición fue exitosa
                {
                    string contenidoAmenazas = resultAmenazas.Content.ReadAsStringAsync().Result;//Obtener el contenido de la respuesta
                    listaAmenazas = JsonSerializer.Deserialize<IEnumerable<AmenazaModel>>(contenidoAmenazas, _serializerOptions);//Deserializar el contenido
                    SelectList amenazas = new SelectList(listaAmenazas, "Id", "Descripcion");//Crear la lista desplegable
                    especieAltaModel.TodasLasAmenazas = amenazas;//Asignar la lista desplegable al modelo
                }

                //Cargar estados de conservación
                var responseEstadosConservacion = _cli.GetAsync(new Uri(_cli.BaseAddress, "estados"));//Obtener la respuesta de la petición
                responseEstadosConservacion.Wait();//Esperar a que termine la petición
                var resultEstadosConservacion = responseEstadosConservacion.Result;//Obtener el resultado de la petición
                if (resultEstadosConservacion.IsSuccessStatusCode)//Si la petición fue exitosa
                {
                    string contenidoEstadosConservacion = resultEstadosConservacion.Content.ReadAsStringAsync().Result;//Obtener el contenido de la respuesta
                    listaEstadosConservacion = JsonSerializer.Deserialize<IEnumerable<EstadoConservacionModel>>(contenidoEstadosConservacion, _serializerOptions);//Deserializar el contenido
                    SelectList estadosConservacion = new SelectList(listaEstadosConservacion, "Id", "Nombre");//Crear la lista desplegable
                    especieAltaModel.TodosLosEstadosConservacion = estadosConservacion;//Asignar la lista desplegable al modelo
                }

                //Cargar ecosistemas
                var responseEcosistemas = _cli.GetAsync(new Uri(_cli.BaseAddress, "ecosistemas"));//Obtener la respuesta de la petición
                responseEcosistemas.Wait();//Esperar a que termine la petición
                var resultEcosistemas = responseEcosistemas.Result;//Obtener el resultado de la petición
                if (resultEcosistemas.IsSuccessStatusCode)//Si la petición fue exitosa
                {
                    string contenidoEcosistemas = resultEcosistemas.Content.ReadAsStringAsync().Result;//Obtener el contenido de la respuesta
                    listaEcosistemas = JsonSerializer.Deserialize<IEnumerable<EcosistemaModel>>(contenidoEcosistemas, _serializerOptions);//Deserializar el contenido
                    SelectList ecosistemasList = new SelectList(listaEcosistemas, "Id", "Nombre");//Crear la lista desplegable
                    especieAltaModel.TodosLosEcosistemas = ecosistemasList;//Asignar la lista desplegable al modelo
                }

            }catch(Exception)
            {
                throw;
            }

            /*IEnumerable<AmenazaModel> amenazasModel = LlenarAmenazas();
            IEnumerable<EstadoConservacionModel> estadosModel = LlenarEstadosConservacion();
            IEnumerable<EcosistemaModel> ecosistemaModels = LlenarEcosistemas();
            SelectList amenazs = new SelectList(amenazasModel, "Id", "Descripcion");
            SelectList estados = new SelectList(estadosModel, "Id", "Nombre");
            SelectList ecosistemas = new SelectList(ecosistemaModels, "Id", "Nombre");

            especieAltaModel.TodasLasAmenazas = amenazs;
            especieAltaModel.TodosLosEstadosConservacion = estados;
            especieAltaModel.TodosLosEcosistemas = ecosistemas;*/
        }

        /*private IEnumerable<EcosistemaModel> LlenarEcosistemas()
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
        }*/

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

        public IActionResult AsignarEspecie()
        {
            var especies = _repoEspecie.GetAll(); // Obtén todas las especies del repositorio
            var ecosistemas = _repoEcosistema.GetAll(); // Obtén todos los ecosistemas del repositorio

            var viewModel = new EspecieAsignarModel
            {
                Especies = especies.Select(especie => new SelectListItem
                {
                    Text = especie.Nombre.NombreVulgar,
                    Value = especie.Id.ToString()
                }).ToList(),
                Ecosistemas = ecosistemas.Select(ecosistema => new SelectListItem
                {
                    Text = ecosistema.Nombre,
                    Value = ecosistema.Id.ToString()
                }).ToList()
            };

            return View(viewModel);


        }

        private IEnumerable<EspecieModel> LlenarEspecies()
        {
            IEnumerable<Especie> especies = _repoEspecie.GetAll();
            IEnumerable<EspecieModel> especieModel = ConversionesEspecie.FromLista(especies);
            return especieModel;
        }

        [HttpPost]
        public IActionResult AsignarEspecie(Models.EspecieAsignarModel especieAsignarModel)
        {
            try
            {
                if(especieAsignarModel == null)
                {
                    throw new Exception("Se debe seleccionar una especie y un ecosistema");
                }

                int especieId = especieAsignarModel.EspecieId;
                int ecosistemaId = especieAsignarModel.EcosistemaId;

                Especie especie = _repoEspecie.FindById(especieId);
                Ecosistema ecosistema = _repoEcosistema.FindById(ecosistemaId);

                if(especie != null && ecosistema != null)
                {
                    if (especie.Ecosistemas.Contains(ecosistema) && ecosistema.Especies.Contains(especie))
                    {
                        throw new Exception("La especie ya se encuentra asignada a ese ecosistema");
                    }
                    else
                    {
                        bool esViable = _repoEspecie.CompararAmenazas(especie, ecosistema);
                        bool esViable2 = _repoEspecie.CompararEstadosConservacion(especie, ecosistema);

                        if (esViable == true && esViable2 == true)
                        {
                            especie.Ecosistemas.Add(ecosistema);
                            ecosistema.Especies.Add(especie);
                            _repoEspecie.Update(especie);
                            _repoEcosistema.Update(ecosistema);
                            TempData["MensajeAsignarEspecie"] = "La especie se asignó correctamente";
                            return RedirectToAction("AsignarEspecie");

                        }
                        else
                        {
                            TempData["MensajeAsignarEspecie"] = "La especie no puede ser asignada a ese ecosistema";
                            throw new Exception("La especie no puede ser asignada a ese ecosistema");
                        }
                    }
                    
                }
                else
                {
                    throw new Exception("La especie o el ecosistema no existen");
                }


            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AsignarEspecie");
            }
        }

        public IActionResult ConsultarEspecies()
        {
            try
            {
                var ecosistemas = _repoEcosistema.GetAll();
                SelectList ecosistemasSelectList = new SelectList(ecosistemas, "Id", "Nombre");
                ViewBag.Ecosistemas = ecosistemasSelectList;

                var especiesDeLaDb = _repoEspecie.GetAll();
                SelectList especiesSelectList = new SelectList(especiesDeLaDb, "Id", "Nombre.NombreVulgar");
                ViewBag.Especies = especiesSelectList;

                IEnumerable<Especie> _especies = _repoEspecie.GetAll();//Obtener todas las especies
                if (_especies.Any())
                {
                    return View(_especies);
                }
                else
                {
                    TempData["Error"] = "No se encontraron especies";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e)
            {

                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]

        public IActionResult ConsultarEspecies(string filter, string NombreCientifico, bool FiltrarPeligroExtincion, string PesoMinimo, string PesoMaximo, int EcosistemaId, int EspecieId)
        {
            var ecosistemas = _repoEcosistema.GetAll();
            SelectList ecosistemasSelectList = new SelectList(ecosistemas, "Id", "Nombre");
            ViewBag.Ecosistemas = ecosistemasSelectList;

            var especiesDeLaDb = _repoEspecie.GetAll();
            SelectList especiesSelectList = new SelectList(especiesDeLaDb, "Id", "Nombre.NombreVulgar");
            ViewBag.Especies = especiesSelectList;

            if (filter == "NombreCientifico")
            {
                var especies = _repoEspecie.SearchByNombreCientifico(NombreCientifico);
                return View(especies);
            }
            else if (FiltrarPeligroExtincion)
            {
                var especies = _repoEspecie.SearchByPeligroExtincion();
                return View(especies);
            }
            else if (filter == "FiltrarPorPeso")
            {
                decimal minimo, maximo;

                if (decimal.TryParse(PesoMinimo, out minimo) && decimal.TryParse(PesoMaximo, out maximo))
                {
                    var especies = _repoEspecie.SearchByPesoRange(minimo, maximo);
                    return View(especies);
                }
            }
            else if (filter == "FiltrarPorEcosistema")
            {
                if(EcosistemaId != null)
                {
                    var especies = _repoEspecie.SearchByEcosistema(EcosistemaId);
                    if (especies != null)
                    {
                           return View(especies);
                    }
                    else
                    {
                        TempData["Error"] = "No se encontraron especies";
                        return View();
                    }
                }

            }
            else if(filter == "FiltrarPorEspecie")
            {
                if(EspecieId != null)
                {
                    var ecosistemasNoHabitables = _repoEcosistema.SearchEcosistemasNoHabitables(EspecieId);//Obtener todos los ecosistemas no habitables
                    return View("EcosistemasNoHabitables", ecosistemasNoHabitables);//Mostrar los ecosistemas no habitables en la vista EcosistemasNoHabitables
                }
            }
            return View();
        }


    }
}
