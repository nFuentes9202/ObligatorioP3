using Dominio.Entidades;
using LogicaAplicacion.InterfacesCasosUso.Especies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obligatorio.WebApi.DTOS;
using Obligatorio.WebApi.DTOS.ConversionesDTO;
using Obligatorio.WebApi.DTOS.Especies;
using Swashbuckle.AspNetCore.Annotations;

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

        /// <summary>
        /// Obtiene un listado de todas las especies disponibles.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET api/Especies
        ///
        /// </remarks>
        /// <returns>Una lista de especies</returns>
        /// <response code="200">Devuelve el listado de especies</response>
        /// <response code="404">Si no se encuentran especies</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene un listado de todas las especies disponibles", Description = "Usa _useCaseGetEspecie.GetEspeciesDTO() para obtener un listado de especies")]
        [ProducesResponseType(typeof(EspecieListadoDTO), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Obtiene el ID de una especie según su nombre científico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET api/Especies/GetIdByNombreCientifico/TyrannosaurusRex
        ///
        /// </remarks>
        /// <param name="nombreCientifico">Nombre científico de la especie a buscar</param>
        /// <returns>ID de la especie</returns>
        /// <response code="200">Devuelve el ID de la especie encontrada</response>
        /// <response code="404">Si no se encuentra una especie con ese nombre científico</response>
        /// <response code="400">Si ocurre un error durante la búsqueda</response>
        [HttpGet("GetIdByNombreCientifico/{nombreCientifico}")]
        [SwaggerOperation(Summary = "Obtiene el ID de una especie según su nombre científico", Description = "Usa _useCaseGetEspecieById.GetIdSegunNombreCientifico(nombreCientifico) para obtener el ID")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> GetIdByNombreCientifico(string nombreCientifico)
        {
            try
            {
                var idEspecie = _useCaseGetEspecieById.GetIdSegunNombreCientifico(nombreCientifico);
                if (idEspecie != null)
                {
                    return Ok(idEspecie);
                }
                else
                {
                    return NotFound("Especie no encontrada.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return BadRequest($"Error al buscar la especie: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea una nueva especie.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     POST api/Especie
        ///     {
        ///        "nombreCientifico": "Nombre Científico",
        ///        "descripcion": "Descripción",
        ///        ...otros campos...
        ///     }
        ///
        /// </remarks>
        /// <param name="especieDTO">Datos de la nueva especie a crear</param>
        /// <returns>Una nueva especie creada</returns>
        /// <response code="201">Si la especie se crea correctamente</response>
        /// <response code="400">Si la entrada es nula o inválida</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Crea una nueva especie", Description = "Usa _useCaseAltaEspecie.Alta(especieDTO) para crear una nueva especie")]
        [ProducesResponseType(typeof(Especie), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<Especie> Post([FromBody] EspecieAltaDTO especieDTO)
        {
            if(especieDTO == null)
            {
                return BadRequest("Debe proporcionar una especie a dar de alta");
            }

            try
            {
                    int Id = _useCaseAltaEspecie.Alta(especieDTO);
                especieDTO.Id = Id;

                return CreatedAtRoute("GetById", new { id = Id }, especieDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Carga una imagen para una especie específica.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     POST api/Especie/CargarImagen?especieId=1
        ///     [form-data con la imagen]
        ///
        /// </remarks>
        /// <param name="imagen">Archivo de imagen a cargar</param>
        /// <param name="especieId">ID de la especie para la cual se carga la imagen</param>
        /// <returns>Resultado de la operación de carga de la imagen</returns>
        /// <response code="200">Si la imagen se carga correctamente</response>
        /// <response code="400">Si los parámetros son nulos o inválidos</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpPost("CargarImagen")]
        [SwaggerOperation(Summary = "Carga una imagen para una especie específica", Description = "Usa GuardarImagen(imagen, especieAltaDto) para cargar y guardar la imagen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CargarImagen(IFormFile imagen, int especieId)
        {
            if (imagen == null || especieId == null)
            {
                return BadRequest("Imagen y/o ID de la especie son requeridos.");
            }
            try
            {


                // Crear un DTO o modelo para pasar a GuardarImagen
                var especieAltaDto = new EspecieAltaDTO
                {
                    Id = especieId,
                    // Otros campos necesarios, si los hay
                };

                bool imagenGuardada = GuardarImagen(imagen, especieAltaDto);

                if (imagenGuardada)
                {
                    // Aquí podrías realizar operaciones adicionales si es necesario
                    return Ok(new { Mensaje = "Imagen cargada con éxito", RutaImagen = especieAltaDto.ImagenRuta });
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
        /// Obtiene una especie por su ID.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET api/Especie/1
        ///
        /// </remarks>
        /// <param name="id">ID de la especie a buscar</param>
        /// <returns>La especie encontrada</returns>
        /// <response code="200">Devuelve la especie encontrada</response>
        /// <response code="400">Si el ID es nulo o inválido</response>
        /// <response code="404">Si no se encuentra una especie con ese ID</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpGet("{id}", Name = "GetEspecieById")]
        [SwaggerOperation(Summary = "Obtiene una especie por su ID", Description = "Usa _useCaseGetEspecieById.GetEspecie(id) para obtener la especie")]
        [ProducesResponseType(typeof(EspecieListadoDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
