
namespace ControlDeCredito.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoDeCliente", Schema = "CC")]
    public partial class TipoDeCliente
    {
        public TipoDeCliente()
        {
            this.Cliente = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 5 caracteres")]
        [Display(Name = "Codigo Tipo: ")]
        public string CodigoTipoDeCliente { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(35, ErrorMessage = "Longitud maxima, 35 caracteres")]
        [Display(Name = "Descripcion Tipo: ")]
        public string DescripcionTipoDeCliente { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
