
namespace ControlDeCredito.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Municipio", Schema = "CC")]
    public partial class Municipio
    {
        public Municipio()
        {
            this.Cliente = new HashSet<Cliente>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 5 caracteres")]
        [Display(Name = "Codigo de Municipio: ")]
        public string CodigoDeMunicipio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(35, ErrorMessage = "Longitud maxima, 35 caracteres")]
        [Display(Name = "Descripcion de Municipio: ")]
        public string DescripcionDeMunicipio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int DepartamentoId { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
