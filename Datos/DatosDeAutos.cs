using Practica3.Modelos.AgenciaAutos;

namespace Practica3.Datos
{
    public static class DatosDeAutos
    {
        public static List<CAutos> ListaAutos = new List<CAutos>
        {
            new CAutos
            {
                ID = 1,
                Nombre = "Citroën C-4 2024",
                Precio = 300000,
                Combustible = "Gasolina",
                Pasajeros = 5,
                Transmision = "Automática",
                Traccion = "Delantera",
                Motor = "4 cilindros"
            },
            new CAutos
            {
                ID = 2,
                Nombre = "Audi A4 Turbo S-Line",
                Precio = 3000000,
                Motor = "2.0, 4 cilindros, Turbo",
                Combustible = "Gasolina",
                Pasajeros = 5,
                Transmision = "Automática",
                Traccion = "2WD",
            }

        };
    }
}
