using Lab.LINQ_Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ_Logic.Services
{
    public class ProductsService : BaseService
    {
        public List<Products> GetProductsNonStock()
        {
            try
            {
                return _context.Products
                    .Where(p => p.UnitsInStock == 0)
                    .ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al encontrar lista de productos sin stock: {exe.Message}");
                return null;
            }
        }

        public Products GetProductsById(int id)
        {
            try
            {
                return _context.Products.FirstOrDefault(p => p.ProductID == id);
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al encontrar producto por el id: {exe.Message}");
                return null;
            }
        }

        public List<Products> GetProductsStockAndPriceGreatThan3()
        {
            try
            {
                return _context.Products
                    .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3)
                    .ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al encontrar lista de productos con stock mayor a 3: {exe.Message}");
                return null;
            }
        }

        public List<Products> GetProductsOrderByName()
        {
            try
            {
                return _context.Products
                    .OrderBy(p => p.ProductName)
                    .ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al encontrar lista de productos ordenados: {exe.Message}");
                return null;
            }
        }

        public List<Products> GetProductsOrderByUnitInStock()
        {
            try
            {
                return _context.Products
                    .OrderByDescending(p => p.UnitsInStock)
                    .ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al encontrar lista de productos ordenados: {exe.Message}");
                return null;
            }
        }

        public Products GetProduct()
        {
            try
            {
                return _context.Products.First();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al encontrar el primer producto: {exe.Message}");
                return null;
            }
        }
    }
}
       
    

