using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Parcial29_6.Models
{
    public class Pagos
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Numero de socio")]
        public string NSocio { get; set; }
        [Required]
        [Display(Name = "Valor de la cuota")]
        [Precision(18, 2)]
        public decimal ValorCuota { get; set; }
        [Required]
        [Display(Name = "Fecha de pago")]
        public DateTime FechadePago { get; set; }
        [Required]
        [Display(Name = "Numero de cuota")]
        public int NroCuota { get; set; }
    }
}
