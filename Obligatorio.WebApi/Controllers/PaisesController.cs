using LogicaAplicacion.CasosUso.DTOS.Paises;
using LogicaAplicacion.InterfacesCasosUso.Paises;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IGetPaises _getPaises;

        public PaisesController(IGetPaises getPaises)
        {
            _getPaises = getPaises;
        }
        // GET: api/<PaisController>
        [HttpGet]
        public ActionResult<PaisDTO> Get()
        {
            try
            {
                IEnumerable<PaisDTO> paises = _getPaises.GetAll();

                if(paises == null || paises.Count() == 0)
                {
                    return NotFound("No existen países");
                }

                return Ok(paises);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        /*
        // GET api/<PaisController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaisController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
