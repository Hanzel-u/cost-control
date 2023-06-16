
namespace ControlDeCredito.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Departamento", Schema = "CC")]
    public partial class Departamento
    {
        public Departamento()
        {
            this.Municipio = new HashSet<Municipio>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 5 caracteres")]
        [Display(Name = "Codigo de Departamento: ")]
        public string CodigoDeDepartamento { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(35, ErrorMessage = "Longitud maxima, 35 caracteres")]
        [Display(Name = "Descripcion de Departamento: ")]
        public string DescripcionDeDepartamento { get; set; }

        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
