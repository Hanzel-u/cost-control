
namespace AutenticacionUNP.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MenuUsuario", Schema = "GU")]

    public partial class MenuUsuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int MenuId { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
