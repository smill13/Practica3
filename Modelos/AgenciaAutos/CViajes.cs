using System.ComponentModel.DataAnnotations;

namespace Practica3.Modelos.AgenciaAutos
{
    public class CViajes
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        public double Precio { get; set; }

        public string Destino { get; set; }

        public string Duracion { get; set; }

        public string TipoTransporte { get; set; }

        public string Alojamiento { get; set; }

        public string Estado { get; set; }
    }
}
