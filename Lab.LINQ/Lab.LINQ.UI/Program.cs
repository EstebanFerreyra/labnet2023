using Lab.LINQ_Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramMenu programMenu = new ProgramMenu(new CustomersService(), new ProductsService(), new CategoriesService());
            programMenu.Menu();
        }
    }
}
