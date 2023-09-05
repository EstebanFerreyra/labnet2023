using Lab.LINQ_Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ_Logic.Services
{
    public class CategoriesService : BaseService
    {
        public List<Categories> GetCategories()
        {
			try
			{
                return _context.Categories
                    .ToList();
            }
			catch (Exception exe)
			{
                Console.WriteLine($"Error al encontrar la lista de categorias: {exe.Message}");
                return null;
			}
        }
    }
}
