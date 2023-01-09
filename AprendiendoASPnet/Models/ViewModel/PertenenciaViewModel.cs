using System.ComponentModel.DataAnnotations;

namespace AprendiendoASPnet.Models.ViewModel
{
    public class PertenenciaViewModel
    {
        [Required]
        [Display(Name = "IdUsuario")]
        public int Id2 { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public double precio { get; set; }
        [Required]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }
    }
}
