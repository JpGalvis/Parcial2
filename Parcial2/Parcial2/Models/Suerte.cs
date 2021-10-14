using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2.Models
{
    public class Suerte
    {
        [Key]
        public string futuro { get; set; }
        [Display(Name = "Nombre completo del autor")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre debe contener entre 3 a 60 caracteres")]
        [Required(ErrorMessage = "El autor es requerido")]
        public string vision { get; set; }
        [Url]
        [Display(Name = "link del video")]
        public string link { get; set; }
    }
}
