using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica3.Datos;
using Practica3.Modelos.AgenciaAutos;

namespace Practica3.Controllers
{
    public class HotelesController : Controller
    {
        #region Trae la lista completa de Hoteles
        [HttpGet]
        [Route("ListarHoteles")]
        public ActionResult<IEnumerable<CHoteles>> GetListaHoteles()
        {
            return Ok(DatosHoteles.ListaHoteles);
        }
        #endregion

        #region traer por el destino

        [HttpGet("HotelesPorDestino")]
        //códigos de estado

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CHoteles> GetHoteles(string City)
        {
            CHoteles hoteles = new CHoteles();
            //validaciones

            if (City == hoteles.Ciudad)
            {
                return BadRequest();
            };

            var Hotel = DatosHoteles.ListaHoteles.FirstOrDefault(a => a.Ciudad == City);

            if (Hotel == null)
            {
                return NotFound();
            }
            return Ok(Hotel);
        }
        #endregion

        #region Eliminar
        [HttpDelete]
        [Route("Eliminar Hotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteHotel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var hotel = DatosHoteles.ListaHoteles.FirstOrDefault(l => l.ID == id);

            if (hotel == null)
            {
                return NotFound();
            }

            DatosHoteles.ListaHoteles.Remove(hotel);
            return NoContent();

        }
        #endregion

        #region Actualizar

        [HttpPut]
        [Route("ActualizarHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateHotel( [FromBody] CHoteles hoteles)
        {

            if (hoteles == null || hoteles.ID == 0)
            {
                return BadRequest();
            }

            var hotel = DatosHoteles.ListaHoteles.FirstOrDefault(l => l.ID == hoteles.ID);

            hotel.Nombre = hoteles.Nombre;
            hotel.Precio = hoteles.Precio;
            hotel.Ciudad = hoteles.Ciudad;
            hotel.TipoHabitacion = hoteles.TipoHabitacion;
            hotel.Capacidad = hoteles.Capacidad;
            hotel.Estado = hoteles.Estado;

            return NoContent();

        }
        #endregion

        #region Crear Hoteles

        [HttpPost]
        [Route("CrearHoteles")]
        // Códigos de estado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CHoteles> CrearHoteles([FromBody] CHoteles hotelesDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (DatosHoteles.ListaHoteles.FirstOrDefault(l => l.Nombre.ToUpper() == hotelesDatos.Nombre.ToUpper()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Ya existe un elemento con este nombre");
                return BadRequest(ModelState);
            }
            else if (hotelesDatos == null)
            {
                return BadRequest(hotelesDatos);
            }

            int maxId = DatosHoteles.ListaHoteles.Max(v => v.ID); // Obtener el ID máximo actual
            hotelesDatos.ID = maxId + 1; // Asignar el siguiente ID incremental

            DatosHoteles.ListaHoteles.Add(hotelesDatos);

            return Ok(hotelesDatos);
        }

        #endregion
    }
}
