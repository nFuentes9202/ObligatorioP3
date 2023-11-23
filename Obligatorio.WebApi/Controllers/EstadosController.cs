using LogicaAplicacion.CasosUso.DTOS.EstadosConservacion;
using LogicaAplicacion.InterfacesCasosUso.EstadosConservacion;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IGetEstadosConservacion _getEstados;

        public EstadosController(IGetEstadosConservacion getEstados)
        {
            _getEstados = getEstados;
        }
        /// <summary>
        /// Obtiene una lista de estados de conservación.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET api/EstadoConservacion
        ///
        /// </remarks>
        /// <returns>Una lista de estados de conservación</returns>
        /// <response code="200">Devuelve la lista de estados de conservación</response>
        /// <response code="404">Si no se encuentran estados de conservación</response>
        /// <response code="500">Si ocurre un error interno en el servidor</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene una lista de estados de conservación", Description = "Usa _getEstados.GetAll() para obtener la lista de estados de conservación")]
        [ProducesResponseType(typeof(EstadoConservacionDTO), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EstadoConservacionDTO> Get()
        {
            try
            {
                var estados = _getEstados.GetAll();

                if(estados == null || estados.Count() == 0)
                {
                    return NotFound("No se encontraron estados de conservación");
                }

                return Ok(estados);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
