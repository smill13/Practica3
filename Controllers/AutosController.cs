using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica3.Datos;
using Practica3.Modelos.AgenciaAutos;
using System.Security.Cryptography.X509Certificates;

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

        #region Traer por nombre
        [HttpGet("ObtenerPorName")]
        //códigos de estado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CAutos> GetAutos(string Name)
        {
            CAutos cAutos = new CAutos();
            //validaciones

            if (Name == cAutos.Nombre)
            {
                return BadRequest();
            };

            var Autos = DatosDeAutos.ListaAutos.FirstOrDefault(a => a.Nombre == Name);

            if (Autos == null)
            {
                return NotFound();
            }
            return Ok(Autos);
        }
        #endregion

        #region Traer por Estado

        [HttpGet("ObtenerPorEstado")]
        //códigos de estado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CAutos> GetAutosEstado(string Estado)
        {
            CAutos cAutos = new CAutos();
            //validaciones

            if (Estado == cAutos.Estado)
            {
                return BadRequest();
            };

            var Autos = DatosDeAutos.ListaAutos.Where(a => a.Estado == Estado);

            if (Autos == null)
            {
                return NotFound();
            }
            return Ok(Autos);
        }

        #endregion

        #region Trae los datos por ID

        [HttpGet("ObtenerPorID", Name = "GetAutos")]
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
        [Route("CrearAutos")]
        // Códigos de estado
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CAutos> CrearAutos([FromBody] CAutos autosDaos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (DatosDeAutos.ListaAutos.FirstOrDefault(l => l.Nombre.ToUpper() == autosDaos.Nombre.ToUpper()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Ya existe un elemento con este nombre");
                return BadRequest(ModelState);
            }
            else if (autosDaos == null)
            {
                return BadRequest(autosDaos);
            }

            int maxId = DatosDeAutos.ListaAutos.Max(v => v.ID); // Obtener el ID máximo actual
            autosDaos.ID = maxId + 1; // Asignar el siguiente ID incremental

            DatosDeAutos.ListaAutos.Add(autosDaos);

            return Ok(autosDaos);
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
        [Route ("ActualizarAuto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateAuto( [FromBody] CAutos autos)
        {

            if (autos == null || autos.ID == 0)
            {
                return BadRequest();
            }

            var auto = DatosDeAutos.ListaAutos.FirstOrDefault(l => l.ID == autos.ID);

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
