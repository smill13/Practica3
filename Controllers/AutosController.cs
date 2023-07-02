using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica3.Datos;
using Practica3.Modelos.AgenciaAutos;

namespace Practica3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        #region Trae la lista completa de autos
        [HttpGet]
        [Route ("Listar")]
        //códigos de estado
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CAutos>> GetListaAutos()
        {
            return Ok(DatosDeAutos.ListaAutos);
        }
        #endregion

        #region Trae los datos por ID

        [HttpGet]
        [Route("Obtener por ID")]
        //códigos de estado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<CAutos> GetAutos(int id)
        {
            //validaciones

            if (id == 0)
            {
                return BadRequest();
            };

            var Autos = DatosDeAutos.ListaAutos.FirstOrDefault(a => a.ID == id);

            if (Autos == null)
            {
                return NotFound();
            }
            return Ok(Autos);
        }
        #endregion

        #region Crear Autos

        [HttpPost]
        [Route("Crear Autos")]
        //códigos de estado
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CAutos> CrearAutos([FromBody] CAutos autosDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (DatosDeAutos.ListaAutos.FirstOrDefault(l => l.Nombre.ToUpper() == autosDatos.Nombre.ToUpper()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Ya exite un elementon con este nombre");
                return BadRequest(ModelState);
            }
            else if (autosDatos == null)
            {
                return BadRequest(autosDatos);
            }
            else if (autosDatos.ID > 0)
            {
                ModelState.AddModelError("!ID = 0", "El ID no debe ser diferente de 0");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            autosDatos.ID = DatosDeAutos.ListaAutos.OrderByDescending(a => a.ID).FirstOrDefault().ID + 1;
            DatosDeAutos.ListaAutos.Add(autosDatos);

            return CreatedAtRoute("ObtenerAuto", new { id = autosDatos.ID }, autosDatos);

        }
        #endregion

        #region Eliminar

        [HttpDelete]
        [Route("Eliminar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteAuto(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var autos = DatosDeAutos.ListaAutos.FirstOrDefault(l => l.ID == id);

            if (autos == null)
            {
                return NotFound();
            }

            DatosDeAutos.ListaAutos.Remove(autos);
            return NoContent();

        }

        #endregion

        #region Actulizar

        [HttpPut]
        [Route ("Actualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateAuto(int id, [FromBody] CAutos autos)
        {

            if (autos == null || id!= autos.ID)
            {
                return BadRequest();
            }

            var auto = DatosDeAutos.ListaAutos.FirstOrDefault(l => l.ID == id);
            auto.Nombre = autos.Nombre;
            auto.Traccion = autos.Traccion;
            auto.Motor = autos.Motor;
            auto.Transmision = autos.Transmision;
            auto.Combustible = autos.Combustible;
            auto.Pasajeros = autos.Pasajeros;
            auto.Precio = autos.Precio;

            return NoContent();

        }

        #endregion
    }

}
