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
using Dominio.ExcepcionesEntidades;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class EcosistemasController : Controller
    {
        private readonly RepositorioEcosistema _repoEcosistema;
        private readonly RepositorioAmenaza _repoAmenaza;
        private IWebHostEnvironment _environment;
        private readonly RepositorioEstadosConservacion _repoEstadosConservacion;
        private readonly RepositorioPais _repoPaises;
        private readonly RepositorioConfiguracion _repoConfiguracion;

        private static HttpClient _cli = new HttpClient();

        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };



        public EcosistemasController(RepositorioEcosistema repoEcosistema, RepositorioAmenaza repoAmenaza, IWebHostEnvironment environment, RepositorioEstadosConservacion repositorioEstadosConservacion, RepositorioPais repoPais, RepositorioConfiguracion repoConfiguracion)
        {
            if (_cli.BaseAddress == null)
            {
                _cli.BaseAddress = new Uri("https://localhost:7082/api/Ecosistema");
            }

            _cli.DefaultRequestHeaders.Accept.Clear();
            _cli.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            _repoEcosistema = repoEcosistema;
            _repoAmenaza = repoAmenaza;
            _environment = environment;
            _repoEstadosConservacion = repositorioEstadosConservacion;
            _repoPaises = repoPais;
            _repoConfiguracion = repoConfiguracion;
        }

        // GET: Ecosistemas
        public ActionResult Index()
        {

            try
            {
                IEnumerable<EcosistemaModel> listaEcosistemas = new List<EcosistemaModel>();

                var respuesta = _cli.GetAsync(_cli.BaseAddress);

                respuesta.Wait();

                var resultado = respuesta.Result;

                if (resultado.IsSuccessStatusCode)
                {
                    string contenidoPublicaciones = resultado.Content.ReadAsStringAsync().Result;
                    listaEcosistemas = JsonSerializer.Deserialize<List<EcosistemaModel>>(contenidoPublicaciones, _serializerOptions);

                    if (listaEcosistemas != null && listaEcosistemas.Count() > 0)
                    {

                        return View(listaEcosistemas);

                    }

                    else
                    {
                        TempData["Error"] = "No hay resultado";
                        return View(listaEcosistemas);
                    }
                }
                string contenidoError = resultado.Content.ReadAsStringAsync().Result;
                TempData["Error"] = $"Error: {contenidoError}";
                return View(listaEcosistemas);
            }
            catch (Exception e)
            {

                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
            

        }

        public IActionResult Create()
        {
            var ecosistemaAltaModel = new EcosistemaAltaModel();
            try
            {
                CargarListaDesplegables(ecosistemaAltaModel);
                if(ecosistemaAltaModel.TodasLasAmenazas == null || ecosistemaAltaModel.TodosLosEstadosConservacion == null || ecosistemaAltaModel.TodosLosPaises == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                ViewData["Error"] = "Problemas al cargar las listas desplegables";
            }

            return View(ecosistemaAltaModel);
        }

        private void CargarListaDesplegables(EcosistemaAltaModel ecoAltaModel)
        {
            try
            {
                IEnumerable<PaisModel> listaPaises = new List<PaisModel>();
                IEnumerable<AmenazaModel> listaAmenazas = new List<AmenazaModel>();
                IEnumerable<EstadoConservacionModel> listaEstadoConservacion = new List<EstadoConservacionModel>();

                //Cargamos los paises
                var respuesta = _cli.GetAsync(new Uri(_cli.BaseAddress, "paises"));
                respuesta.Wait();
                var resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    string contenidoPaises = resultado.Content.ReadAsStringAsync().Result;
                    listaPaises = JsonSerializer.Deserialize<IEnumerable<PaisModel>>(contenidoPaises, _serializerOptions);
                    SelectList paises = new SelectList(listaPaises, "Id", "Nombre");
                    ecoAltaModel.TodosLosPaises = paises;
                }

                //Cargamos las amenazas
                respuesta = _cli.GetAsync(new Uri(_cli.BaseAddress, "amenazas"));
                respuesta.Wait();
                resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    string contenidoAmenazas = resultado.Content.ReadAsStringAsync().Result;
                    listaAmenazas = JsonSerializer.Deserialize<IEnumerable<AmenazaModel>>(contenidoAmenazas, _serializerOptions);
                    SelectList amenazas = new SelectList(listaAmenazas, "Id", "Descripcion");//esta llamando a listaPaises deberia ir listaAmenazas
                    ecoAltaModel.TodasLasAmenazas = amenazas;
                }

                //Cargamos los estados de conservación
                respuesta = _cli.GetAsync(new Uri(_cli.BaseAddress, "estados"));
                respuesta.Wait();
                resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    string contenidoEstados = resultado.Content.ReadAsStringAsync().Result;
                    listaEstadoConservacion = JsonSerializer.Deserialize<IEnumerable<EstadoConservacionModel>>(contenidoEstados, _serializerOptions);
                    SelectList estados = new SelectList(listaEstadoConservacion, "Id", "Nombre");//esta llamando a listaPaises deberia ir listaEstadoConservacion
                    ecoAltaModel.TodosLosEstadosConservacion = estados;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
         * 
         * Codigo viejo, no lo borro por si lo precisamos de alguna manera
         * 
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
        */

        [HttpPost]
        [RequestSizeLimit(104857600)]
        public IActionResult Create(EcosistemaAltaModel ecosistemaModel)
        {
            var ecosistemaModelCarga = new EcosistemaAltaModel();
            try
            {
                if (ecosistemaModel == null)
                {
                    return View();
                }

                using (var formData = new MultipartFormDataContent())
                {
                    // Agregar propiedades básicas
                    //formData.Add(new StringContent(ecosistemaModel.Id.ToString()));
                    formData.Add(new StringContent(ecosistemaModel.Nombre));
                    formData.Add(new StringContent(ecosistemaModel.AreaMetrosCuadrados.ToString()));
                    formData.Add(new StringContent(ecosistemaModel.Descripcion));
                    formData.Add(new StringContent(ecosistemaModel.Latitud.ToString(CultureInfo.InvariantCulture)));
                    formData.Add(new StringContent(ecosistemaModel.Longitud.ToString(CultureInfo.InvariantCulture)));
                    formData.Add(new StringContent(ecosistemaModel.EstadoConservacionId.ToString()));

                    // Agregar la imagen, si está presente
                    if (ecosistemaModel.Imagen != null)
                    {
                        var streamContent = new StreamContent(ecosistemaModel.Imagen.OpenReadStream());
                        streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            Name = "Imagen",
                            FileName = ecosistemaModel.Imagen.FileName
                        };
                        formData.Add(streamContent, "Imagen", ecosistemaModel.Imagen.FileName);
                    }

                    // Agregar descripción de la imagen
                    if (!string.IsNullOrWhiteSpace(ecosistemaModel.DescripcionImagen))
                    {
                        formData.Add(new StringContent(ecosistemaModel.DescripcionImagen), "DescripcionImagen");
                    }

                    // Agregar IDs de amenazas seleccionadas
                    foreach (var amenazaId in ecosistemaModel.AmenazasSeleccionadasIds)
                    {
                        formData.Add(new StringContent(amenazaId.ToString()), "AmenazasSeleccionadasIds");
                    }
                    foreach (var amenazaId in ecosistemaModel.AmenazasSeleccionadasIds)
                    {
                        formData.Add(new StringContent(amenazaId.ToString()), "AmenazasSeleccionadasIds");
                    }

                    // Agregar IDs de países
                    foreach (var paisId in ecosistemaModel.PaisId)
                    {
                        formData.Add(new StringContent(paisId.ToString()), "PaisId");
                    }

                    var respuesta = _cli.PostAsync(_cli.BaseAddress, formData).Result;


                    if (respuesta.IsSuccessStatusCode)
                    {
                        TempData["Feedback"] = "Se dió de alta correctamente el ecosistema";
                        CargarListaDesplegables(ecosistemaModelCarga);
                        return View(ecosistemaModelCarga);

                    }
                    var contenidoError = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception($"No se pudo guardar el ecosistema: {contenidoError}");
                }
            }

            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                CargarListaDesplegables(ecosistemaModelCarga);
                return View(ecosistemaModelCarga);

            }
        }
        /*
         * Metodo migrado a la webapi
        private bool GuardarImagen(IFormFile imagen, EcosistemaAltaModel eco)
        {
            try
            {
                if (imagen == null || eco == null)
                {
                    throw new Exception("Es necesario subir una imagen");
                }
                // SUBIR LA IMAGEN
                //ruta física de wwwroot
                var extension = Path.GetExtension(imagen.FileName).ToLower();
                if(extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                {
                    throw new Exception("La extensión de la imagen no es válida. Solo se permiten .jpg, .jpeg y .png.");
                }
                string rutaFisicaWwwRoot = _environment.WebRootPath;

                //ruta donde se guardan las fotos de las personas
                string rutaFisicaFoto = Path.Combine
                (rutaFisicaWwwRoot, "imagenes", "ecosistemas");

                if (!Directory.Exists(rutaFisicaFoto))
                {
                    Directory.CreateDirectory(rutaFisicaFoto);
                }
                //Generamos el nombre
                int sufijo = 1;
                string nombreImagen;
                do
                {
                    nombreImagen = $"{eco.Id}_{sufijo.ToString("D3")}{extension}";
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
        */
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
