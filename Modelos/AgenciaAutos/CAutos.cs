using Microsoft.AspNetCore.Server.IIS.Core;
using System.ComponentModel.DataAnnotations;

namespace Practica3.Modelos.AgenciaAutos
{
    public class CAutos
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Motor { get; set; }
        public string Combustible { get; set; }
        public int Pasajeros { get; set; }
        public string Transmision { get; set; }
        public string Traccion { get; set; }
        public string Estado { get; set; }

    }
}
