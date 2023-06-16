
namespace AutenticacionUNP.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Menu", Schema = "GU")]
    public partial class Menu
    {
        public Menu()
        {
            this.MenuUsuario = new HashSet<MenuUsuario>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 10 caracteres")]
        [Display(Name = "Codigo: ")]
        public string CodigoMenu { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 50 caracteres")]
        [Display(Name = "Descripcion: ")]
        public string DescripcionMenu { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 100 caracteres")]
        [Display(Name = "UrlMenu: ")]
        public string UrlMenu { get; set; }
    
        public virtual ICollection<MenuUsuario> MenuUsuario { get; set; }
    }
}
