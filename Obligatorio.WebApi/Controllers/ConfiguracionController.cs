using Dominio.Entidades;
using LogicaAplicacion.CasosUso.DTOS.Configuracion;
using LogicaAplicacion.InterfacesCasosUso.Configuracion;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private IModificarConfiguracion _cuModificarConfig;

        public ConfiguracionController(IModificarConfiguracion cuModificarconfig) {
            _cuModificarConfig = cuModificarconfig;
        }

        // GET: api/<ConfiguracionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConfiguracionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConfiguracionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConfiguracionController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConfiguracionDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ConfiguracionValidaciones> Put(int? id, [FromBody] ConfiguracionDTO configDTO)
        {
            if(id == null)
            {
                return BadRequest("Debe proporcionar la id de la configuración a editar");
            }
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

        // DELETE api/<ConfiguracionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
