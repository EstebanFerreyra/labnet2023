using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public class ProgramMenu
    {
        private readonly EmployeesService _employeesService;
        private readonly CustomersService _customersService;

        public ProgramMenu()
        {
            _employeesService = new EmployeesService();
            _customersService = new CustomersService();
        }

        public void ListEmployees()
        {
            var listEmployees = _employeesService.GetAll();

            if (listEmployees == null)
            {
                Console.WriteLine("Ocurrio un error al intentar mostrar la lista de empleados");
            }
            else
            {
                foreach (Employees item in listEmployees)
                {
                    Console.WriteLine($"{item.EmployeeID} - {item.FirstName} {item.LastName}");
                }
            }
        }

        public void ListCustomers()
        {
            var listCustomers = _customersService.GetAll();

            if (listCustomers == null)
            {
                Console.WriteLine("Ocurrio un error al intentar mostrar la lista de clientes");
            }
            else
            {
                foreach (Customers item in listCustomers)
                {
                    Console.WriteLine($"{item.CustomerID} - {item.ContactName}");
                }
            }
        }

        public void ABMCustomers()
        {
            Console.WriteLine("Case 3");
        }

        public void ABMEmployees()
        {
            Console.WriteLine("Case 4");
        }

        public void Menu()
        {
            bool exit = false;

            while (!exit)
            {
                MenuOptions();
                int option;

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    InvalidInput();
                }

                switch (option)
                {
                    case 1:
                        ListCustomers();
                        Continue();
                        Console.ReadKey();
                        break;

                    case 2:
                        ListEmployees();
                        Continue();
                        Console.ReadKey();
                        break;

                    case 3:
                        ABMCustomers();
                        Continue();
                        Console.ReadKey();
                        break;

                    case 4:
                        ABMEmployees();
                        Continue();
                        Console.ReadKey();
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        InvalidInput();
                        Continue();
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void MenuOptions()
        {
            Console.Clear();
            Console.WriteLine("MENU NORTHWIND");
            Console.WriteLine("1 - Listado de clientes");
            Console.WriteLine("2 - Listado de empleados");
            Console.WriteLine("3 - ABM de clientes");
            Console.WriteLine("4 - ABM de empleados");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Ingrese una opcion: ");
        }

        public void InvalidInput()
        {
            Console.WriteLine("Ingrese un caracter válido (0 - 1 - 2 - 3 - 4)");
        }

        public void Continue()
        {
            Console.WriteLine("Pulse una tecla para continuar...");
        }
    }
}
