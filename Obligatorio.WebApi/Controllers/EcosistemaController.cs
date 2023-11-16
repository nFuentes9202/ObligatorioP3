using Dominio.Entidades;
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
        private IGetEcosistemas _useCaseGetAll;
        private IAltaEcosistema _useCaseAltaEcosistema;
        private IGetEcosistemaById _useCaseGetEcosistema;
        public EcosistemaController(IGetEcosistemas get, IAltaEcosistema altaEco, IGetEcosistemaById useCaseGetEcosistema) {
            _useCaseGetAll = get;
            _useCaseAltaEcosistema = altaEco;
            _useCaseGetEcosistema = useCaseGetEcosistema;
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
        [HttpPost]
        public ActionResult<Ecosistema>Post([FromBody] EcosistemaAltaDTO ecosistemaDTO)
        {
            if(ecosistemaDTO == null)
            {
                return BadRequest("Debe proporcionar el ecosistema a dar de alta");
            }
            try
            {
                _useCaseAltaEcosistema.Alta(ecosistemaDTO);
                return CreatedAtRoute("GetById", new {id = ecosistemaDTO.Id}, ecosistemaDTO);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
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
