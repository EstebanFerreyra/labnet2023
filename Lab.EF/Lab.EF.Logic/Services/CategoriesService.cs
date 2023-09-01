using Lab.EF.Data.Context;
using Lab.EF.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Services
{
    public class CategoriesService
    {
        private readonly NorthwindContext _northwindContext;
        public CategoriesService(NorthwindContext context)
        {
            _northwindContext = context;
        }

        public CategoriesService()
        {
            _northwindContext = new NorthwindContext();
        }

        public List<Categories> GetAll()
        {
            try
            {
                return _northwindContext.Categories.ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al intentar mostrar la lista de categorias: {exe.Message}");
                return null;
            }
        }

        public void Add(Categories categorie)
        {
            try
            {
                _northwindContext.Categories.Add(categorie);
                _northwindContext.SaveChanges();
                Console.WriteLine("Categoria agregada con exito");
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al intentar agregar una categoria: {exe.Message}");
            }
        }
    }
}
