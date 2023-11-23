using LogicaAplicacion.CasosUso.DTOS.Amenazas;
using LogicaAplicacion.InterfacesCasosUso.Amenazas;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        /// <summary>
        /// Obtiene todas las amenazas disponibles.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET /Amenazas
        ///
        /// </remarks>
        /// <returns>Una lista de amenazas</returns>
        /// <response code="200">Devuelve la lista de amenazas</response>
        /// <response code="404">Si no se encuentran amenazas</response> 
        /// <response code="500">Si ocurre un error interno en el servidor</response> 
        [SwaggerOperation(Summary = "Obtiene todas las amenazas disponibles", Description = "Usa _getAmenazas.GetAll() para obtener todas las amenazas")]
        [ProducesResponseType(typeof(IEnumerable<AmenazaDTO>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
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

    }
}
