using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Parcial29_6.Models
{
    public class Socios
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Actividad { get; set; }
        [Required]
        [Display(Name = "Numero de socio")]
        public int NSocio { get; set; }
    }
}
