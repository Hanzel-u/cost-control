
namespace ControlDeCredito.Models
{
    using System;
    using System.Collections.Generic;
   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Sexo", Schema = "CC")]
    public partial class Sexo
    {
        public Sexo()
        {
            this.Cliente = new HashSet<Cliente>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 5 caracteres")]
        [Display(Name = "Codigo de Sexo: ")]
        public string CodigoDeSexo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, ErrorMessage = "Longitud maxima, 20 caracteres")]
        [Display(Name = "Descripcion de Sexo: ")]
        public string DescripcionDeSexo { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
