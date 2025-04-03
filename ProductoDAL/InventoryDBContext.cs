using Microsoft.EntityFrameworkCore;
using SysInventory.EN;

namespace SysInventory.DAL
{
    public class InventoryDBContext : DbContext

    {
        public InventoryDBContext(DbContextOptions<InventoryDBContext> Options) : base(Options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para DetalleCompra
            modelBuilder.Entity<DetalleCompra>()
                .HasOne(d => d.Compra)
                .WithMany(c => c.DetalleCompras)
                .HasForeignKey(d => d.IdCompra);

            // Configuración para DetalleVenta 
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.DetalleVenta)
                .HasForeignKey(d => d.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}