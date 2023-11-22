using LogicaAplicacion.CasosUso.DTOS.Amenazas;
using LogicaAplicacion.InterfacesCasosUso.Amenazas;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenazasController : ControllerBase
    {
        private readonly IGetAmenazas _getAmenazas;

        public AmenazasController(IGetAmenazas getAmenazas)
        {
            _getAmenazas = getAmenazas;
        }
        // GET: api/<AmenazasController>
        [HttpGet]
        public ActionResult<AmenazaDTO> Get()
        {
            try
            {
                var amenazas = _getAmenazas.GetAll();

                if(amenazas == null || amenazas.Count() == 0)
                {
                    return NotFound("No hay amenazas");
                }

                return Ok(amenazas);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        /*
        // GET api/<AmenazasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AmenazasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AmenazasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AmenazasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
