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
        public DbSet<Roll> Rolls { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Reporte> Reporte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Producto>(P =>
            {
                P.HasKey(P => P.Id);
                P.Property(p => p.CategoriaId).IsRequired();
                P.Property(p => p.NombreProducto).IsRequired().HasMaxLength(50);
                P.Property(p => p.DescripcionProducto).IsRequired();
                P.Property(p => p.PrecioProducto).IsRequired();
                P.Property(p => p.EstadoProducto).IsRequired();
                P.Property(p => p.ImagenProducto).IsRequired();                
            });
                       

            modelBuilder.Entity<Categoria>(C => {
                C.HasKey(c=>c.Id);
                C.Property(c => c.NombreCategoria).IsRequired();
            });

            modelBuilder.Entity<Usuario>(U => {
                U.HasKey(u => u.Id);
                U.Property(u=>u.Nombre).IsRequired().HasMaxLength(20);
                U.Property(u=>u.Apellidos).IsRequired().HasMaxLength(50);
                U.Property(u=>u.Correo).IsRequired().HasMaxLength(70);
                U.Property(u=>u.Contrasena).IsRequired().HasMaxLength(16);
                U.Property(u=>u.EstadoUsuario).IsRequired();
            });

            modelBuilder.Entity<Roll>(R => {
                R.HasKey(r => r.IdRoll);
                R.Property(r => r.NombreRoll).IsRequired().HasMaxLength(20);
            });
            modelBuilder.Entity<Venta>(V => {
                V.HasKey(v => v.Id);
                V.Property(v=>v.ClienteId).IsRequired();
                V.Property(v=>v.NombreCliente).IsRequired().HasMaxLength(70);
                V.Property(v=>v.CorreoCliente).IsRequired().HasMaxLength(70);
                V.Property(v=>v.MontoPago).IsRequired();
                V.Property(v=>v.FechaRegistro).IsRequired();
            });

            modelBuilder.Entity<DetalleVenta>(DV => {
                DV.HasKey(v => v.Id);
            });

			modelBuilder.Entity<Producto>().HasOne(z => z.Categoria).WithMany(z => z.Productos).HasForeignKey(z => z.CategoriaId);
			modelBuilder.Entity<DetalleVenta>().HasOne(z => z.Venta).WithMany(z => z.DetalleVentas).HasForeignKey(z => z.VentaId);
			modelBuilder.Entity<Usuario>().HasOne(z => z.Roll).WithMany(z => z.Usuarios).HasForeignKey(z => z.RollId);



		}
    }

}
