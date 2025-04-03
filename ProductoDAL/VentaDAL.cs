using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using SysInventory.EN;
using SysInventory.EN.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysInventory.DAL
{
    public class VentaDAL
    {
        readonly InventoryDBContext _dBContext;
        public VentaDAL(InventoryDBContext inventoryDBContext)
        {
            _dBContext = inventoryDBContext;
        }

        public async Task<int> CrearAsync(Venta pVenta)
        {
            // Agregar la Venta con sus detalles
            _dBContext.Ventas.Add(pVenta);
            int result = await _dBContext.SaveChangesAsync();
            if (result > 0)
            {
                // Actualizar stock de productos
                foreach (var detalle in pVenta.DetalleVenta)
                {
                    var venta = await _dBContext.Ventas.FirstOrDefaultAsync(p => p.Id == detalle.Id);
                    if (venta != null)
                    {
                        venta.Cantidad += detalle.Cantidad;
                    }
                }
            }
            return await _dBContext.SaveChangesAsync();
        }
        public async Task<int> AnularAsync(int Id)
        {
            var venta = await _dBContext.Ventas
                .Include(c => c.DetalleVenta)
                .FirstOrDefaultAsync(c => c.Id == Id);

            if (venta != null && venta.Estado != (byte)Venta.EnumEstadoVenta.Anulada)
            {
                // Marcar la venta como anulada
                venta.Estado = (byte)Venta.EnumEstadoVenta.Anulada;

                // Actualizar el stock de los productos relacionados
                foreach (var detalle in venta.DetalleVenta)
                {
                    var producto = await _dBContext.Productos
                        .FirstOrDefaultAsync(p => p.IdProducto == detalle.IdProducto); // Corregido para usar IdProducto

                    if (producto != null)
                    {
                        producto.CantidadDisponible += detalle.Cantidad; // Corregido para usar 'producto' en lugar de 'Venta'
                    }
                }

                // Guardar los cambios en la base de datos
                return await _dBContext.SaveChangesAsync();
            }

            // Si la venta no existe o ya está anulada, devolver 0
            return 0;
        }
        public async Task<Venta> ObtenerPorIdAsync(int Id)
        {
            return await _dBContext.Ventas
                .Include(c => c.DetalleVenta)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }
        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            return await _dBContext.Ventas
                .Include(c => c.DetalleVenta)
                .ThenInclude(d => d.Producto)
                .ToListAsync();
        }
        public async Task<List<Venta>> ObtenerPorEstadoAsync(byte estado)
        {
            var ventasQuery = _dBContext.Ventas.AsQueryable();

            if (estado != 0)
            {
                ventasQuery = ventasQuery.Where(c => c.Estado == estado);
            }

            ventasQuery = ventasQuery
                .Include(c => c.DetalleVenta)
                .Include(c => c.Producto);

            var compras = await ventasQuery.ToListAsync();

            return compras ?? new List<Venta>();
        }

    }
}
