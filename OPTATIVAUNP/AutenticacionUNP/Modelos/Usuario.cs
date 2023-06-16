
namespace AutenticacionUNP.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Usuario", Schema = "GU")]

    public partial class Usuario
    {
        public Usuario()
        {
            this.DetallePermiso = new HashSet<DetallePermiso>();
            this.MenuUsuario = new HashSet<MenuUsuario>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 30 caracteres")]
        [Display(Name = "Nombres: ")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 30 caracteres")]
        [Display(Name = "Apellido1: ")]
        public string Apellido1 { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 30 caracteres")]
        [Display(Name = "Apellido2: ")]
        public string Apellido2 { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 15 caracteres")]
        [Display(Name = "Usuario: ")]
        public string CuentaUsuario { get; set; }
    
        public virtual ICollection<DetallePermiso> DetallePermiso { get; set; }
        public virtual ICollection<MenuUsuario> MenuUsuario { get; set; }
    }
}
