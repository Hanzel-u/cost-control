
namespace ControlDeCredito.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Recibo", Schema = "CC")]
    public partial class Recibo
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 5 caracteres")]
        [Display(Name = "Numero de Recibo: ")]
        public string NumeroDeRecibo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.DateTime)]
        [DefaultValue("01/01/2000")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime FecheDeRecibo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal MontoRecibo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public short NumeroDeCuotaPagada { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ContratoId { get; set; }

        public virtual Contrato Contrato { get; set; }
    }
}
