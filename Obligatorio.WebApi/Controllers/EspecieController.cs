using Dominio.Entidades;
using LogicaAplicacion.InterfacesCasosUso.Especies;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApi.DTOS.Especies;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : Controller
    {
        private IAltaEspecie _useCaseAltaEspecie;
        private IAsignarEspecie _useCaseAsignarEspecie;
        private IGetEspecies _useCaseGetEspecie;

        public EspecieController(IAltaEspecie useCaseAltaEspecie, IAsignarEspecie useCaseAsignarEspecie, IGetEspecies useCaseGetEspecie)
        {
            _useCaseAltaEspecie = useCaseAltaEspecie;
            _useCaseAsignarEspecie = useCaseAsignarEspecie;
            _useCaseGetEspecie = useCaseGetEspecie;
        }
        /*
        //GET: api/<EspecieController>
        [HttpGet]
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
        }*/

        // POST api/<EspecieController>
        [HttpPost]
        public ActionResult<Especie> Post([FromBody] EspecieAltaDTO especieDTO)
        {
            if(especieDTO == null)
            {
                return BadRequest("Debe proporcionar una especie a dar de alta");
            }

            try
            {
                _useCaseAltaEspecie.Alta(especieDTO);
                return CreatedAtRoute("GetById", new { id = especieDTO.Id }, especieDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
