using LogicaAplicacion.InterfacesCasosUso.Ecosistemas;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApi.DTOS.Ecosistemas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcosistemaController : ControllerBase
    {
        private IGetEcosistemas _get;
        public EcosistemaController(IGetEcosistemas get) {
            _get = get;
        }
        // GET: api/<EcosistemaController>
        [HttpGet]
        public IActionResult Get()
        {
            var ecosistemas = _get.GetAll();
            var ecosistemasDTO = MapeoEcosistema.FromLista(ecosistemas);
            return Ok(ecosistemasDTO);
        }

        // GET api/<EcosistemaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EcosistemaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EcosistemaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EcosistemaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
