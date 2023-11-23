using Dominio.Entidades;
using LogicaAplicacion.InterfacesCasosUso.Ecosistemas;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApi.DTOS;
using Obligatorio.WebApi.DTOS.ConversionesDTO;
using Obligatorio.WebApi.DTOS.Ecosistemas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcosistemaController : ControllerBase
    {
        private IGetEcosistemas _useCaseGetAll;
        private IAltaEcosistema _useCaseAltaEcosistema;
        private IGetEcosistemaById _useCaseGetEcosistema;
        private IBorrarEcosistema _useCaseBorrarEcosistema;

        private IWebHostEnvironment _env;
        public EcosistemaController(IGetEcosistemas get, IAltaEcosistema altaEco, IGetEcosistemaById useCaseGetEcosistema, IBorrarEcosistema useCaseBorrarEcosistema, IWebHostEnvironment env)
        {
            _useCaseGetAll = get;
            _useCaseAltaEcosistema = altaEco;
            _useCaseGetEcosistema = useCaseGetEcosistema;
            _useCaseBorrarEcosistema = useCaseBorrarEcosistema;
            _env = env;
        }
        // GET: api/<EcosistemaController>
        [HttpGet]
        public ActionResult<EcosistemaListadoDTO> GetEcosistemas()
        {
            try
            {
                var ecosistemas = _useCaseGetAll.GetEcosistemasDTO();
                if(ecosistemas == null)
                {
                    return NotFound();
                }
                return Ok(ecosistemas);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetById")] //Se  pone nombre a la ruta para usarla en el CreatedAtRoute
        public ActionResult<EcosistemaListadoDTO> Get(int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Debe proporcionar el id a buscar");
                var ecosistema = _useCaseGetEcosistema.GetEcosistema(id);
                if (ecosistema == null)
                    return NotFound($"No existe el autor con el id {id}");
                return Ok(ecosistema);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // POST api/<EcosistemaController>
        [HttpPost("")]
        public ActionResult<Ecosistema>Post([FromForm] EcosistemaAltaImagenDTO ecosistemaDTO)
        {
            if(ecosistemaDTO == null)
            {
                return BadRequest("Debe proporcionar el ecosistema a dar de alta");
            }
            try
            {
                
                var ecosistema = MapeosEco.conversion(ecosistemaDTO);


                if(GuardarImagen(ecosistemaDTO.Imagen, ecosistema))
                {
                    _useCaseAltaEcosistema.Alta(ecosistema);
                }
                else
                {
                    return BadRequest("No se pudo guardar la imagen");
                }
                
                return CreatedAtRoute("GetById", new {id = ecosistemaDTO.Id}, ecosistemaDTO);
            }
            catch (Exception e)
            {
                if(e.InnerException != null)
                {
                    return BadRequest($"Se produjo un error: {e.Message} - {e.InnerException.Message}");
                }
                return BadRequest(e.Message);
            }
        }

        private bool GuardarImagen(IFormFile imagen, EcosistemaAltaDTO eco)
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
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                {
                    throw new Exception("La extensión de la imagen no es válida. Solo se permiten .jpg, .jpeg y .png.");
                }
                string rutaFisicaWwwRoot = _env.WebRootPath;

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

        // PUT api/<EcosistemaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EcosistemaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest("Debe proporcionar la id del ecosistema");
            }
            try
            {
                _useCaseBorrarEcosistema.Eliminar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
