
namespace ControlDeCredito.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contrato", Schema = "CC")]
    public partial class Contrato
    {
        public Contrato()
        {
            this.Recibo = new HashSet<Recibo>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 5 caracteres")]
        [Display(Name = "Codigo de Contraro: ")]
        public string CodigoDeContrato { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.DateTime)]
        [DefaultValue("01/01/2000")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime FechaDeContrato { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal ComisionDeContrato { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal MontoBasicoDeContrato { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal MontoAcobrar { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public short CantidadDeCuotas { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ClienteId { get; set; }
        
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Recibo> Recibo { get; set; }
    }
}
