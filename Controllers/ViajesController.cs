using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica3.Datos;
using Practica3.Modelos.AgenciaAutos;

namespace Practica3.Controllers
{
    public class ViajesController : Controller
    {
        #region Trae la lista completa de viajes
        [HttpGet]
        [Route("ListarViajes")]
        public ActionResult<IEnumerable<CViajes>> GetListaViajes()
        {
            return Ok(DatosViajes.ListaViajes);
        }
        #endregion

        #region traer por el destino
        [HttpGet("ViajesPorDestino")]
        //códigos de estado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CViajes> GetViaje(string Name)
        {
            CViajes viaje = new();
            //validaciones

            if (Name == viaje.Nombre )
            {
                return BadRequest();
            };

            var Viaje = DatosViajes.ListaViajes.FirstOrDefault(a => a.Nombre == Name);

            if (Viaje == null)
            {
                return NotFound();
            }
            return Ok(Viaje);
        }
        #endregion

        #region Eliminar

        [HttpDelete]
        [Route("Eliminar Viaje")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteViaje(int id)
        {
            if (id == 0) 
            { 
                return BadRequest();
            }

            var viaje = DatosViajes.ListaViajes.FirstOrDefault(l => l.ID == id);

            if (viaje == null)
            {
                return NotFound();
            }

            DatosViajes.ListaViajes.Remove(viaje);
            return NoContent();
        }
        #endregion

        #region Actualizar

        [HttpPut]
        [Route("ActualizarViaje")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateViaje([FromBody] CViajes cViajes)
        {
            if (cViajes == null || cViajes.ID == 0)
            {
                return BadRequest();
            }

            var viaje = DatosViajes.ListaViajes.FirstOrDefault(l => l.ID == cViajes.ID);

            if (viaje == null)
            {
                return BadRequest();
            }

            viaje.Nombre = cViajes.Nombre;
            viaje.Precio = cViajes.Precio;
            viaje.Destino = cViajes.Destino;
            viaje.Duracion = cViajes.Duracion;
            viaje.TipoTransporte = cViajes.TipoTransporte;
            viaje.Alojamiento = cViajes.Alojamiento;
            viaje.Estado = cViajes.Estado;

            return NoContent();
        }

        #endregion



        #region Crear viajes
        [HttpPost]
        [Route("CrearViajes")]
        // Códigos de estado
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CViajes> CrearViajes([FromBody] CViajes viajesDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (DatosViajes.ListaViajes.FirstOrDefault(l => l.Nombre.ToUpper() == viajesDatos.Nombre.ToUpper()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Ya existe un elemento con este nombre");
                return BadRequest(ModelState);
            }
            else if (viajesDatos == null)
            {
                return BadRequest(viajesDatos);
            }

            int maxId = DatosViajes.ListaViajes.Max(v => v.ID); // Obtener el ID máximo actual
            viajesDatos.ID = maxId + 1; // Asignar el siguiente ID incremental

            DatosViajes.ListaViajes.Add(viajesDatos);

            return Ok(viajesDatos);
        }

        #endregion
    }
}
