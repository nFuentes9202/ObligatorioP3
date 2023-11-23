using Dominio.Entidades;
using LogicaAplicacion.InterfacesCasosUso.Especies;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApi.DTOS;
using Obligatorio.WebApi.DTOS.ConversionesDTO;
using Obligatorio.WebApi.DTOS.Especies;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : Controller
    {
        private IAltaEspecie _useCaseAltaEspecie;
        private IGetEspecies _useCaseGetEspecie;
        private IGetEspecieById _useCaseGetEspecieById;

        private IWebHostEnvironment _env;


        public EspecieController(IAltaEspecie useCaseAltaEspecie, IGetEspecies useCaseGetEspecie, IWebHostEnvironment env)
        {
            _useCaseAltaEspecie = useCaseAltaEspecie;
            _useCaseGetEspecie = useCaseGetEspecie;
            _env = env;
        }
        
        //GET: api/<EspecieController>
        [HttpGet]
        public ActionResult<EspecieListadoDTO> GetEspecies()
        {
            try
            {
                var especies = _useCaseGetEspecie.GetEspeciesDTO();
                if (especies == null)
                {
                    return NotFound();
                }
                return Ok(especies);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        // POST api/<EspecieController>
        [HttpPost]
        public ActionResult<Especie> Post([FromForm] EspecieAltaImagenDTO especieDTO)
        {
            if(especieDTO == null)
            {
                return BadRequest("Debe proporcionar una especie a dar de alta");
            }

            try
            {
                var especie = MapeosEspecie.conversion(especieDTO);

                if (GuardarImagen(especieDTO.Imagen, especie))
                {
                    _useCaseAltaEspecie.Alta(especie);
                }
                else
                {
                    return BadRequest("No se pudo guardar la imagen");
                }

                return CreatedAtRoute("GetById", new { id = especieDTO.Id }, especieDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private bool GuardarImagen(IFormFile imagen, EspecieAltaDTO esp)
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
                string rutaFisicaWwwRoot = _env.WebRootPath;

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

        [HttpGet("{id}", Name = "GetEspecieById")] //Se  pone nombre a la ruta para usarla en el CreatedAtRoute
        public ActionResult<EspecieListadoDTO> Get(int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Debe proporcionar el id a buscar");
                var especie = _useCaseGetEspecieById.GetEspecie(id);
                if (especie == null)
                    return NotFound($"No existe la especie con el id {id}");
                return Ok(especie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
