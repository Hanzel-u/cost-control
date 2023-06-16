
namespace AutenticacionUNP.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class GUContainer : DbContext
    {
        public GUContainer()
            : base("name=GUContainer")
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
    
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<DetallePermiso> DetallePermisos { get; set; }
        public DbSet<MenuUsuario> MenuUsuarios { get; set; }
    }
}
