using Dominio.Entidades;
using LogicaAplicacion.CasosUso.DTOS.Configuracion;
using LogicaAplicacion.InterfacesCasosUso.Configuracion;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApi.DTOS.Ecosistemas;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.WebApi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly IGetConfiguracion _cuGetConfig;
        private IModificarConfiguracion _cuModificarConfig;

        public ConfiguracionController(IModificarConfiguracion cuModificarconfig, IGetConfiguracion cuGetConfig)
        {
            _cuModificarConfig = cuModificarconfig;
            _cuGetConfig = cuGetConfig;
        }

        /// <summary>
        /// Obtiene la configuración actual del ecosistema.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET api/Ecosistema
        ///
        /// </remarks>
        /// <returns>Configuración del ecosistema</returns>
        /// <response code="200">Devuelve la configuración actual del ecosistema</response>
        /// <response code="404">Si la configuración no se encuentra</response> 
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene la configuración actual del ecosistema", Description = "Usa _cuGetConfig.GetConfiguracionPrimera() para obtener la configuración")]
        [ProducesResponseType(typeof(ConfiguracionDTO), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ConfiguracionDTO> GetConfiguracion()
        {
            try
            {
                var configuracion = _cuGetConfig.GetConfiguracionPrimera();
                if (configuracion == null)
                {
                    return NotFound();
                }
                return Ok(configuracion);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Actualiza la configuración específica por su ID.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     PUT api/Configuracion/1
        ///     {
        ///        "id": 1,
        ///        "nombre": "Nueva Configuración",
        ///        "valor": "Valor"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">ID de la configuración a actualizar</param>
        /// <param name="configDTO">Datos de la configuración a actualizar</param>
        /// <returns>Configuración actualizada</returns>
        /// <response code="200">Si la configuración se actualiza correctamente</response>
        /// <response code="400">Si los datos de entrada son inválidos o no coinciden</response>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Actualiza la configuración específica por su ID", Description = "Usa _cuModificarConfig.Modificar() para actualizar la configuración")]
        [ProducesResponseType(typeof(ConfiguracionDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ConfiguracionValidaciones> Put(int? id, [FromBody] ConfiguracionDTO configDTO)
        {
            id = 1;
            configDTO.Id = (int)id;

            if(configDTO == null)
            {
                return BadRequest("Debe proporcionar la configuración a editar");
            }
            if (id == 0 || configDTO.Id == 0 || id != configDTO.Id) { 
                return BadRequest("El autor debe tener el mismo id que la clave a buscar y ninguno debe ser cero");

            }
            try
            {
                _cuModificarConfig.Modificar(configDTO);
                return Ok(configDTO);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
