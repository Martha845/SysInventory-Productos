using SysInventory.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SysInventory.DAL
{
    public class ProveedorDAL
    {
        readonly InventoryDBContext _dbContext;
        public ProveedorDAL(InventoryDBContext context)
        {
            _dbContext = context;
        }
        public async Task<int> CrearAsync(Proveedor pProveedor)
        {
            Proveedor proveedor = new Proveedor()
            {
                Nombre = pProveedor.Nombre,
                NRC = pProveedor.NRC,
                Direccion = pProveedor.Direccion,
                Telefono = pProveedor.Telefono,
                Email = pProveedor.Email,
            };

            _dbContext.Add(proveedor);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> EliminarAsync(Proveedor pProveedor)
        {
            var proveedor = _dbContext.Proveedores.FirstOrDefault(s => s.Id == pProveedor.Id);
            if (proveedor != null)
            {
                _dbContext.Proveedores.Remove(proveedor);
                return await _dbContext.SaveChangesAsync();
            }
            else
                return 0;
        }
        public async Task<int> ModificarAsync(Proveedor pProveedor)
        {
            var proveedor = _dbContext.Proveedores.FirstOrDefault(s => s.Id == pProveedor.Id);
            if (proveedor != null && proveedor.Id > 0)
            {
                _dbContext.Proveedores.Update(pProveedor);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
        public async Task<Proveedor> ObtenerPorIdAsync(Proveedor pProveedor)
        {
            var proveedor = await _dbContext.Proveedores.FirstOrDefaultAsync(s => s.Id == pProveedor.Id);
            if (proveedor != null && proveedor.Id != 0)
            {
                return new Proveedor
                {
                    Nombre = pProveedor.Nombre,
                    NRC = pProveedor.NRC,
                    Direccion = pProveedor.Direccion,
                    Telefono = pProveedor.Telefono,
                    Email = pProveedor.Email,
                };
            }
            else
                return new Proveedor();
        }

        public async Task<List<Proveedor>> ObtenerTodosAsync(Proveedor pProveedor)
        {
            var proveedor = await _dbContext.Proveedores.ToListAsync();

            if (pProveedor != null && proveedor.Count > 0)
            {
                var lista = new List<Proveedor>();
                proveedor.ForEach(s => lista.Add(new Proveedor
                {
                    Nombre = s.Nombre,
                    NRC = s.NRC,
                    Direccion = s.Direccion,
                    Telefono = s.Telefono,
                    Email = s.Email,
                }));
                return lista;
            }
            else
            {
                return new List<Proveedor>();
            }
        }
    }
}
