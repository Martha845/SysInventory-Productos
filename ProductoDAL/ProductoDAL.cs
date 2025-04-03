using Microsoft.EntityFrameworkCore;
using SysInventory.EN;

namespace SysInventory.DAL
{
    public class ProductoDAL
    {
        readonly InventoryDBContext _dbContext;

        public ProductoDAL(InventoryDBContext context)
        {
            _dbContext = context;
        }

        public async Task<int> CrearAsync(Producto pProducto)
        {
            Producto producto = new Producto()
            {
                Nombre = pProducto.Nombre,
                Precio = pProducto.Precio,
                CantidadDisponible = pProducto.CantidadDisponible,
                FechaCreacion = pProducto.FechaCreacion,
            };

            _dbContext.Add(producto);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> EliminarAsync(Producto pProducto)
        {
            var producto = await _dbContext.Productos.FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);
            if (producto != null)
            {
                _dbContext.Productos.Remove(producto);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> ModificarAsync(Producto pProducto)
        {
            var producto = await _dbContext.Productos.FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);
            if (producto != null)
            {
                producto.Nombre = pProducto.Nombre;
                producto.Precio = pProducto.Precio;
                producto.CantidadDisponible = pProducto.CantidadDisponible;
                producto.FechaCreacion = pProducto.FechaCreacion;

                _dbContext.Productos.Update(producto);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            var producto = await _dbContext.Productos.FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);
            if (producto != null)
            {
                return producto;
            }
            return null;
        }

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            var productos = await _dbContext.Productos.ToListAsync();
            return productos;
        }
    }
}

