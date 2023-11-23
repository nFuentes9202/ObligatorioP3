using Dominio.Entidades;
using LogicaAccesoDatos.RepositoriosEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Text.Json;

namespace MVC.Controllers
{
    public class ConfiguracionController : Controller
    {
        public ConfiguracionController(RepositorioConfiguracion repoConfiguracion)
        {
            if (_cli.BaseAddress == null)
            {
                _cli.BaseAddress = new Uri("https://localhost:7082/api/Configuracion");
            }

            _cli.DefaultRequestHeaders.Accept.Clear();
            _cli.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        private static HttpClient _cli = new HttpClient();

        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };


        public IActionResult Index()
        {
            try
            {
                ConfiguracionModel configuracionModel = new ConfiguracionModel();

                var respuesta = _cli.GetAsync(_cli.BaseAddress);

                respuesta.Wait();

                var resultado = respuesta.Result;

                if (resultado.IsSuccessStatusCode)
                {
                    string contenidoConfiguracion = resultado.Content.ReadAsStringAsync().Result;
                    configuracionModel = JsonSerializer.Deserialize<ConfiguracionModel>(contenidoConfiguracion, _serializerOptions);

                    if (configuracionModel != null)
                    {

                        return View(configuracionModel);

                    }

                    else
                    {
                        TempData["Error"] = "No hay resultado";
                        return View(configuracionModel);
                    }
                }
                string contenidoError = resultado.Content.ReadAsStringAsync().Result;
                TempData["Error"] = $"Error: {contenidoError}";
                return View(configuracionModel);
            }
            catch (Exception e)
            {

                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult GuardarTopes(ConfiguracionModel configuracion)
        {
            try
            {
                if(configuracion == null)
                {
                    throw new Exception("No se puede tener configuracion nula");
                }
                var configSerializada = JsonSerializer.Serialize(configuracion);
                var contenido = new StringContent(configSerializada, System.Text.Encoding.UTF8, "application/json");
                var respuesta = _cli.PutAsync(_cli.BaseAddress + $"/{configuracion.Id}", contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                var contenidoError = respuesta.Content.ReadAsStringAsync().Result;
                throw new Exception($"No se pudo guardar el ecosistema: {contenidoError}");
            }
            catch (Exception e)
            {

                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }

        }
    }
}
