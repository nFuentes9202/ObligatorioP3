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
        private IWebHostEnvironment _environment;

        private static HttpClient _cli = new HttpClient();

        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };



        public EcosistemasController(IWebHostEnvironment environment)
        {
            if (_cli.BaseAddress == null)
            {
                _cli.BaseAddress = new Uri("https://localhost:7082/api/Ecosistema");
            }

            _cli.DefaultRequestHeaders.Accept.Clear();
            _cli.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            _environment = environment;

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
            ecosistemaModel.DescripcionImagen = ecosistemaModel.Descripcion;
            ecosistemaModel.ImagenRuta = "Nula por ahora";
            try
            {
                if (ecosistemaModel == null)
                {
                    return View();
                }

                var ecosistemaSerializado = JsonSerializer.Serialize(ecosistemaModel);
                var contenido = new StringContent(ecosistemaSerializado, System.Text.Encoding.UTF8, "application/json");
                var respuesta = _cli.PostAsync(_cli.BaseAddress, contenido).Result;


                if (respuesta.IsSuccessStatusCode)
                {
                    var respuestaString = respuesta.Content.ReadAsStringAsync().Result;
                    int ecosistemaId = 0;
                    using (JsonDocument doc = JsonDocument.Parse(respuestaString))
                    {
                        JsonElement root = doc.RootElement;
                        ecosistemaId = root.GetProperty("id").GetInt32();

                    }

                    if (ecosistemaModel.Imagen != null)
                    {
                        using (var formData = new MultipartFormDataContent())
                        {
                            var streamContent = new StreamContent(ecosistemaModel.Imagen.OpenReadStream());
                            streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "imagen",
                                FileName = ecosistemaModel.Imagen.FileName
                            };
                            formData.Add(streamContent, "Imagen", ecosistemaModel.Imagen.FileName);
                            formData.Add(new StringContent(ecosistemaId.ToString()), "ecosistemaId");



                            var respuestaImagen = _cli.PostAsync($"{_cli.BaseAddress}/CargarImagen?especieId={ecosistemaId}", formData).Result;

                            if (!respuestaImagen.IsSuccessStatusCode)
                            {
                                // Manejar error en la carga de la imagen
                                var errorResponse = respuestaImagen.Content.ReadAsStringAsync().Result;
                                TempData["Error"] = $"Problema al cargar la imagen: {errorResponse}";
                                return RedirectToAction("Create");
                            }
                        }
                    }
                }
                // Realiza la solicitud GET 





                TempData["Error"] = $"Se carga correctamente!";

                return RedirectToAction("Create");
            }



            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                CargarListaDesplegables(ecosistemaModelCarga);
                return View(ecosistemaModelCarga);

            }
        }

        public IActionResult Borrar(int id)
        {
            try
            {
                var respuesta = _cli.DeleteAsync(_cli.BaseAddress + $"/{id}");
                var resultado = respuesta.Result;
                if(respuesta.Result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    TempData["Feedback"] = $"Se eliminó el ecosistema con id {id}";
                }
                else
                {
                    TempData["Error"] = $"Error: {respuesta.Result.ReasonPhrase} ";

                }


                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {

                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }      
        }
    }
}
