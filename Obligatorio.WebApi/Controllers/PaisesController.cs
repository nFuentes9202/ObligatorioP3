using LogicaAplicacion.CasosUso.DTOS.Paises;
using LogicaAplicacion.InterfacesCasosUso.Paises;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        /// <summary>
        /// Obtiene una lista de países.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET api/Pais
        ///
        /// </remarks>
        /// <returns>Una lista de países</returns>
        /// <response code="200">Devuelve la lista de países</response>
        /// <response code="404">Si no se encuentran países</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene una lista de países", Description = "Usa _getPaises.GetAll() para obtener la lista de países")]
        [ProducesResponseType(typeof(IEnumerable<PaisDTO>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    }
}
