using System.ComponentModel.DataAnnotations;

namespace Practica3.Modelos.AgenciaAutos
{
    public class CHoteles
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        public double Precio { get; set; }

        public string Ciudad { get; set; }

        public string TipoHabitacion { get; set; }

        public int Capacidad { get; set; }

        public string Estado { get; set; }
    }
}
