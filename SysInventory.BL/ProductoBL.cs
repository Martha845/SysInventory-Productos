using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using SysInventory.DAL;
using SysInventory.EN;

namespace SysInventory.BL
{
    public class ProductoBL
    {
        private readonly ProductoDAL _productoDAL;

        public ProductoBL(ProductoDAL productoDAL)
        {
            _productoDAL = productoDAL;
        }

        public async Task<int> CrearAsync(Producto producto)
        {
            try
            {
                return await _productoDAL.CrearAsync(producto);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error al crear producto: {ex.Message}");
                throw;
            }
        }

        public async Task<int> ModificarAsync(Producto producto)
        {
            try
            {
                return await _productoDAL.ModificarAsync(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar producto: {ex.Message}");
                throw;
            }
        }

        public async Task<int> EliminarAsync(Producto producto)
        {
            try
            {
                return await _productoDAL.EliminarAsync(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar producto: {ex.Message}");
                throw;
            }
        }

        public async Task<Producto> ObtenerPorIdAsync(Producto producto)
        {
            try
            {
                return await _productoDAL.ObtenerPorIdAsync(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener producto por ID: {ex.Message}");
                throw;
            }
        }

        public ProductoDAL Get_productoDAL()
        {
            return _productoDAL;
        }

        public async Task<List<Producto>> ObtenerTodosAsync(ProductoDAL _productoDAL)
        {
            try
            {
                return await _productoDAL.ObtenerTodosAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los productos: {ex.Message}");
                throw;
            }
        }
    }
}