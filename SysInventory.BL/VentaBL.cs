using SysInventory.DAL;
using SysInventory.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysInventory.BL
{
    public class VentaBL
    {
        readonly VentaDAL ventaDAL;

        public VentaBL(VentaDAL pVentaDAL)
        {
            ventaDAL = pVentaDAL;
        }

        public async Task<int> CrearAsync(Venta pVenta)
        {
            return await ventaDAL.CrearAsync(pVenta);
        }

        public async Task<int> AnularAsync(int Id)
        {
            return await ventaDAL.AnularAsync(Id);
        }

        public async Task<Venta> ObtenerPorIdAsync(int Id)
        {
            return await ventaDAL.ObtenerPorIdAsync(Id);
        }

        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            return await ventaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Venta>> ObtenerPorEstadoAsync(byte estado)
        {
            return await ventaDAL.ObtenerPorEstadoAsync(estado);
        }
    }
}
