using Practica3.Modelos.AgenciaAutos;

namespace Practica3.Datos
{
    public class DatosHoteles
    {
        public static CViajes CViajes { get; set; }

        public static List<CHoteles> ListaHoteles = new List<CHoteles>
        {
            new CHoteles
            {
                ID = 1,
                Nombre = "Hotel ABC",
                Precio = 200,
                Ciudad = ObtenerDestinoPorID(1),
                TipoHabitacion = "Individual",
                Capacidad = 1,
                Estado = "Disponible"
            },
            new CHoteles
            {
                ID = 2,
                Nombre = "Hotel XYZ",
                Precio = 300,
                Ciudad = ObtenerDestinoPorID(2),
                TipoHabitacion = "Doble",
                Capacidad = 2,
                Estado = "Disponible"
            },
            new CHoteles
            {
                ID = 3,
                Nombre = "Hotel QWE",
                Precio = 250,
                Ciudad = ObtenerDestinoPorID(3),
                TipoHabitacion = "Individual",
                Capacidad = 1,
                Estado = "Disponible"
            },
            new CHoteles
            {
                ID = 4,
                Nombre = "Hotel ASD",
                Precio = 400,
                Ciudad = ObtenerDestinoPorID(4) ,
                TipoHabitacion = "Doble",
                Capacidad = 2,
                Estado = "Disponible"
            },
            new CHoteles
            {
                ID = 5,
                Nombre = "Hotel ZXC",
                Precio = 350,
                Ciudad = ObtenerDestinoPorID(5),
                TipoHabitacion = "Individual",
                Capacidad = 1,
                Estado = "Disponible"
            },
            new CHoteles
            {
                ID = 6,
                Nombre = "Hotel FGH",
                Precio = 300,
                Ciudad = ObtenerDestinoPorID(6),
                TipoHabitacion = "Doble",
                Capacidad = 2,
                Estado = "Disponible"
            },
            new CHoteles
            {
                ID = 7,
                Nombre = "Hotel JKL",
                Precio = 280,
                Ciudad = ObtenerDestinoPorID(7),
                TipoHabitacion = "Individual",
                Capacidad = 1,
                Estado = "Disponible"
            },
            new CHoteles
            {
                ID = 8,
                Nombre = "Hotel MNB",
                Precio = 380,
                Ciudad = ObtenerDestinoPorID(8),
                TipoHabitacion = "Doble",
                Capacidad = 2,
                Estado = "Disponible"
            },
            new CHoteles
            {
                ID = 9,
                Nombre = "Hotel VBN",
                Precio = 320,
                Ciudad = ObtenerDestinoPorID(9),  
                TipoHabitacion = "Individual",
                Capacidad = 1,
                Estado = "Disponible"
            },
            new CHoteles
            {
                ID = 10,
                Nombre = "Hotel POI",
                Precio = 420,
                Ciudad = ObtenerDestinoPorID(10),
                TipoHabitacion = "Doble",
                Capacidad = 2,
                Estado = "Disponible"
            }
        };

        private static string ObtenerDestinoPorID(int viajeID)
        {
            CViajes viaje = DatosViajes.ListaViajes.FirstOrDefault(v => v.ID == viajeID);
            if (viaje != null)
            {
                return viaje.Destino;
            }
            return string.Empty; // Si no se encuentra el viaje, devuelve una cadena vacía
        }
    }

}
