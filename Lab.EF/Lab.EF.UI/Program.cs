using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Interfaces;
using Lab.EF.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgramMenu programMenu = new ProgramMenu(new EmployeesService(), new CustomersService(), new CategoriesService());
            programMenu.Menu();
        }
    }
}
