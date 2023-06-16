
namespace AutenticacionUNP.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Permiso", Schema = "GU")]

    public partial class Permiso
    {
        public Permiso()
        {
            this.DetallePermiso = new HashSet<DetallePermiso>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 10 caracteres")]
        [Display(Name = "Codigo: ")]
        public string CodigoPermiso { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 30 caracteres")]
        [Display(Name = "Descripcion: ")]
        public string DescripcionPermiso { get; set; }
    
        public virtual ICollection<DetallePermiso> DetallePermiso { get; set; }
    }
}
