using Microsoft.EntityFrameworkCore;

namespace PAWS_ProyectoFinal.Models
{
    public class PAWSContext : DbContext
    {
        public PAWSContext(DbContextOptions<PAWSContext> opciones)
            : base(opciones)
        {

        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Reporte> Reporte { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Producto>(P =>
            {
                P.HasKey(z => z.Id);
                P.Property(p => p.CategoriaId).IsRequired();
                P.Property(p => p.NombreProducto).IsRequired();
                P.Property(p => p.DescripcionProducto).IsRequired();
                P.Property(p => p.PrecioProducto).IsRequired();
                P.Property(p => p.EstadoProducto).IsRequired();
                P.Property(p => p.ImagenProducto).IsRequired();                
            });

            modelBuilder.Entity<Producto>().HasOne(z => z.Categoria).WithMany(z => z.Productos).HasForeignKey(z => z.CategoriaId);
        }
    }

}
