
namespace ControlDeCredito.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cliente", Schema = "CC")]
    public partial class Cliente
    {
        public Cliente()
        {
            this.Contrato = new HashSet<Contrato>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 5 caracteres")]
        [Display(Name = "Codigo del Cliente: ")]
        public string CodigoDeCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(35, ErrorMessage = "Longitud maxima, 35 caracteres")]
        [Display(Name = "Nombres del Cliente: ")]
        public string NombresDeCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]        
        [StringLength(35, ErrorMessage = "Longitud maxima, 35 caracteres")]
        [Display(Name = "Primer Apellido: ")]
        public string Apellido1DeCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longitud maxima, 5 caracteres")]
        [DefaultValue("-")]
        [Display(Name = "Segundo Apellido: ")]
        public string Apellido2DeCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(80, ErrorMessage = "Longitud maxima, 80 caracteres")]
        [Display(Name = "Direccion del Cliente: ")]
        public string DireccionDeCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(15, ErrorMessage = "Longitud maxima, 15 caracteres")]
        [Display(Name = "Telefono del Cliente: ")]
        public string TelefonoDeCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.DateTime)]
        [DefaultValue("01/01/2000")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime FechaNacimientoDeCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int TipoDeClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int SexoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int MunicipioId { get; set; }


        public virtual TipoDeCliente TipoDeCliente { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
