using Dominio.Entidades;
using LogicaAplicacion.CasosUso.DTOS.Configuracion;
using LogicaAplicacion.InterfacesCasosUso.Configuracion;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApi.DTOS.Ecosistemas;

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

        // GET: api/<EcosistemaController>
        [HttpGet]
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

        // PUT api/<ConfiguracionController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConfiguracionDTO))]
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
