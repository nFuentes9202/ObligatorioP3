using Dominio.Entidades;
using LogicaAplicacion.InterfacesCasosUso.Ecosistemas;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApi.DTOS;
using Obligatorio.WebApi.DTOS.ConversionesDTO;
using Obligatorio.WebApi.DTOS.Ecosistemas;
using Obligatorio.WebApi.DTOS.Especies;
using Swashbuckle.AspNetCore.Annotations;

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
        /// <summary>
        /// Obtiene un listado de todos los ecosistemas disponibles.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET api/Ecosistema
        ///
        /// </remarks>
        /// <returns>Una lista de ecosistemas</returns>
        /// <response code="200">Devuelve el listado de ecosistemas</response>
        /// <response code="404">Si no se encuentran ecosistemas</response> 
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene un listado de todos los ecosistemas disponibles", Description = "Usa _useCaseGetAll.GetEcosistemasDTO() para obtener un listado de ecosistemas")]
        [ProducesResponseType(typeof(EcosistemaListadoDTO), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Obtiene los detalles de un ecosistema específico por su ID.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET api/Ecosistema/5
        ///
        /// </remarks>
        /// <param name="id">ID del ecosistema a buscar</param>
        /// <returns>Detalles del ecosistema solicitado</returns>
        /// <response code="200">Devuelve el ecosistema solicitado</response>
        /// <response code="400">Si el ID no es proporcionado</response>
        /// <response code="404">Si no se encuentra el ecosistema con el ID especificado</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpGet("{id}", Name = "GetById")]
        [SwaggerOperation(Summary = "Obtiene los detalles de un ecosistema específico por su ID", Description = "Usa _useCaseGetEcosistema.GetEcosistema(id) para obtener un ecosistema específico")]
        [ProducesResponseType(typeof(EcosistemaListadoDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Crea un nuevo ecosistema.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     POST api/Ecosistema
        ///     {
        ///        "nombre": "Nuevo Ecosistema",
        ///        "descripcion": "Descripción del Ecosistema",
        ///        ...otros campos...
        ///     }
        ///
        /// </remarks>
        /// <param name="ecosistemaDTO">Datos del nuevo ecosistema a crear</param>
        /// <returns>Un nuevo ecosistema creado</returns>
        /// <response code="201">Si el ecosistema se crea correctamente</response>
        /// <response code="400">Si la entrada es nula o inválida</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpPost("")]
        [SwaggerOperation(Summary = "Crea un nuevo ecosistema", Description = "Usa _useCaseAltaEcosistema.Alta(ecosistemaDTO) para crear un nuevo ecosistema")]
        [ProducesResponseType(typeof(Ecosistema), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("")]
        public ActionResult<Ecosistema>Post([FromBody] EcosistemaAltaDTO ecosistemaDTO)
        {
            if (ecosistemaDTO == null)
            {
                return BadRequest("Debe proporcionar una especie a dar de alta");
            }

            try
            {
                int Id = _useCaseAltaEcosistema.Alta(ecosistemaDTO);
                ecosistemaDTO.Id = Id;

                return CreatedAtRoute("GetById", new { id = Id }, ecosistemaDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Carga una imagen para un ecosistema específico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     POST api/Ecosistema/CargarImagen?ecosistemaId=1
        ///     [form-data con la imagen]
        ///
        /// </remarks>
        /// <param name="imagen">Archivo de imagen a cargar</param>
        /// <param name="ecosistemaId">ID del ecosistema para el cual se carga la imagen</param>
        /// <returns>Resultado de la operación de carga de la imagen</returns>
        /// <response code="200">Si la imagen se carga correctamente</response>
        /// <response code="400">Si los parámetros son nulos o inválidos</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpPost("CargarImagen")]
        [SwaggerOperation(Summary = "Carga una imagen para un ecosistema específico", Description = "Usa GuardarImagen(imagen, ecosistemaAltaDTO) para cargar y guardar la imagen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CargarImagen(IFormFile imagen, [FromQuery] int ecosistemaId)
        {
            if (imagen == null || ecosistemaId == null)
            {
                return BadRequest("Imagen y/o ID de la especie son requeridos.");
            }
            try
            {


                // Crear un DTO o modelo para pasar a GuardarImagen
                var ecosistemaAltaDTO = new EcosistemaAltaDTO
                {
                    Id = ecosistemaId,
                    // Otros campos necesarios, si los hay
                };

                bool imagenGuardada = GuardarImagen(imagen, ecosistemaAltaDTO);

                if (imagenGuardada)
                {
                    // Aquí podrías realizar operaciones adicionales si es necesario
                    return Ok(new { Mensaje = "Imagen cargada con éxito"});
                }
                else
                {
                    return BadRequest("No se pudo guardar la imagen.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al cargar la imagen: {ex.Message}");
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
                /*
                //Generamos el nombre
                int sufijo = 1;
                string nombreImagen;
                do
                {
                    nombreImagen = $"{eco.Id}_{sufijo.ToString("D3")}{extension}";
                    sufijo++;
                } while (System.IO.File.Exists(Path.Combine(rutaFisicaFoto, nombreImagen)));
                */
                //FileStream permite manejar archivos
                try
                {
                    //el método using libera los recursos del objeto FileStream al finalizar
                    using (FileStream f = new FileStream(Path.Combine(rutaFisicaFoto, imagen.FileName), FileMode.Create))
                    {
                        //Para archivos grandes o varios archivos usar la versión
                        //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                        imagen.CopyTo(f);
                    }
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

        /// <summary>
        /// Elimina un ecosistema específico por su ID.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     DELETE api/Ecosistema/5
        ///
        /// </remarks>
        /// <param name="id">ID del ecosistema a eliminar</param>
        /// <returns>Una respuesta sin contenido si la eliminación es exitosa</returns>
        /// <response code="204">Si el ecosistema se elimina correctamente</response>
        /// <response code="400">Si el ID no es proporcionado o es inválido</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Elimina un ecosistema específico por su ID", Description = "Usa _useCaseBorrarEcosistema.Eliminar(id) para eliminar un ecosistema")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
