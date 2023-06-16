
namespace ControlDeCredito.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class ControlDeCreditoContainer : DbContext
    {
        public ControlDeCreditoContainer()
            : base("name=ControlDeCreditoContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Eliminar la convención de pluralizar nombres de tablas...
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Eliminar la convención On delete cascade en relaciones 1-M...
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Eliminar la convención On delete cascade en relaciones M-M...
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }

        public IDbSet<TipoDeCliente> TipoDeCliente { get; set; }
        public IDbSet<Cliente> Cliente { get; set; }
        public IDbSet<Sexo> Sexo { get; set; }
        public IDbSet<Departamento> Departamento { get; set; }
        public IDbSet<Municipio> Municipio { get; set; }
        public IDbSet<Contrato> Contrato { get; set; }
        public IDbSet<Recibo> Recibo { get; set; }
    }
}


