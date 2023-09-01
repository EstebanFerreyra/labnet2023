using Lab.EF.Entities.DTO;
using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public class ProgramMenu
    {
        private readonly EmployeesService _employeesService;
        private readonly CustomersService _customersService;
        private readonly CategoriesService _categoriesService;

        public ProgramMenu(EmployeesService employeesService, CustomersService customersService, CategoriesService categoriesService)
        {
            _employeesService = employeesService;
            _customersService = customersService;
            _categoriesService = categoriesService;
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
                    Console.WriteLine($"Id: {item.EmployeeID} | Nombre: {item.FirstName} {item.LastName} | Telefono: {item.HomePhone}");
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
                    Console.WriteLine($"Id: {item.CustomerID} | Nombre: {item.ContactName} | Compania: {item.CompanyName} | Telefono: {item.Phone}");
                }
            }
        }

        public void ListCategories()
        {
            var listCategories = _categoriesService.GetAll();

            if (listCategories == null)
            {
                Console.WriteLine("Ocurrio un error al intentar mostrar la lista de categorias");
            }
            else
            {
                foreach (Categories item in listCategories)
                {
                    Console.WriteLine($"Id: {item.CategoryID} | Nombre: {item.CategoryName}");
                }
            }
        }

        public void AddCustomer()
        {
            CustomersDTO customersDTO = new CustomersDTO();
            
            Console.WriteLine("CARGA DE DATOS DEL CLIENTE NUEVO");
            Console.WriteLine("Nombre de compania: ");
            customersDTO.CompanyName = ValidationString(40, Console.ReadLine());
            Console.WriteLine("Nombre de contacto: ");
            customersDTO.ContactName = ValidationString(30, Console.ReadLine());
            Console.WriteLine("Direccion: ");
            customersDTO.Address = ValidationString(60, Console.ReadLine());
            Console.WriteLine("Telefono: ");
            customersDTO.Phone = ValidationString(24, Console.ReadLine());
            string id = IdGenerator(customersDTO.CompanyName);

            _customersService.Add(new Customers
            {
                CustomerID = id,
                CompanyName = customersDTO.CompanyName,
                ContactName = customersDTO.ContactName,
                Address = customersDTO.Address,
                Phone = customersDTO.Phone
            });
        }

        public void UpdateCustomer()
        {
            Console.WriteLine("ACTUALIZACION DE TELEFONO DE CLIENTE");
            Console.WriteLine("Ingrese el id del cliente que desee modificar su telefono: ");

            string id = ValidationString(5, Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo numero de telefono: ");
            string phone = ValidationString(24, Console.ReadLine());
            bool flag = _customersService.Update(id, phone);
            if (!flag) Console.WriteLine("No se encontro cliente o ocurrio un error");
        }

        public void RemoveCustomer()
        {
            Console.WriteLine("ELIMINACION DE CLIENTE");
            Console.WriteLine("Ingrese el id del cliente que desea eliminar: ");

            string id = ValidationString(5, Console.ReadLine());
            bool flag = _customersService.Delete(id);
            if (!flag) Console.WriteLine("No se encontro cliente o ocurrio un error");
        }

        public void AddEmployee()
        {
            EmployeesDTO employeesDTO = new EmployeesDTO();

            Console.WriteLine("CARGA DE DATOS DEL EMPLEADO NUEVO");
            Console.WriteLine("Nombre: ");
            employeesDTO.FirstName = ValidationString(10, Console.ReadLine());
            Console.WriteLine("Apellido: ");
            employeesDTO.LastName = ValidationString(20, Console.ReadLine());
            Console.WriteLine("Direccion: ");
            employeesDTO.Address = ValidationString(60, Console.ReadLine());
            Console.WriteLine("Ciudad: ");
            employeesDTO.City = ValidationString(15, Console.ReadLine());
            Console.WriteLine("Telefono: ");
            employeesDTO.HomePhone = ValidationString(24, Console.ReadLine());

            _employeesService.Add(new Employees
            {
                FirstName = employeesDTO.FirstName,
                LastName = employeesDTO.LastName,
                Address = employeesDTO.Address,
                City = employeesDTO.City,
                HomePhone = employeesDTO.HomePhone
            });
        }

        public void UpdateEmployee()
        {
            Console.WriteLine("ACTUALIZACION DE TELEFONO DE EMPLEADO");
            Console.WriteLine("Ingrese el id del empleado que desee modificar su telefono: ");

            string id = ValidationInt(5, Console.ReadLine()).ToString();
            Console.WriteLine("Ingrese el nuevo numero de telefono: ");
            string phone = ValidationString(24, Console.ReadLine());
            bool flag = _employeesService.Update(id, phone);
            if (!flag) Console.WriteLine("No se encontro empleado o ocurrio un error");
        }

        public void RemoveEmployee()
        {
            Console.WriteLine("ELIMINACION DE EMPLEADO");
            Console.WriteLine("Ingrese el id del elmpleado que desea eliminar: ");

            string id = ValidationInt(5, Console.ReadLine()).ToString();
            bool flag = _employeesService.Delete(id);
            if (!flag) Console.WriteLine("No se encontro elmpleado o ocurrio un error");
        }

        public void AddCategory()
        {
            CategoriesDTO categoriesDTO = new CategoriesDTO();

            Console.WriteLine("CARGA DE DATOS DE LA NUEVA CATEGORIA");
            Console.WriteLine("Nombre: ");
            categoriesDTO.CategoryName = ValidationString(15, Console.ReadLine());
            Console.WriteLine("Descripcion: ");
            categoriesDTO.Description = ValidationString(100, Console.ReadLine());

            _categoriesService.Add(new Categories
            {
                CategoryName = categoriesDTO.CategoryName,
                Description = categoriesDTO.Description
            });
        }

        public int ValidationInt(int maxLength, string input)
        {
            int id;
            while ((!int.TryParse(input, out id)) || (input.Length > maxLength))
            {
                Console.WriteLine("Ingrese un valor válido:");
                input = Console.ReadLine();
            }
            return id;
        }

        public string ValidationString(int maxLength, string input)
        {
            while ((input.Length < 5) || (input.Length > maxLength))
            {
                Console.WriteLine("Ingrese un valor válido:");
                input = Console.ReadLine();
            }
            return input;
        }

        public string IdGenerator(string stringToConvert)
        {
            return stringToConvert.Substring(0, 5).ToUpper();
        }

        public void MenuABM(string nameService)
        {
            const string customers = "clientes";
            Console.WriteLine($"ABM {nameService}");
            Console.WriteLine("1 - Alta | 2 - Modificacion | 3 - Baja | 0 - Salir");
            bool exit = false;
            while (!exit)
            {
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    InvalidInput("0 - 1 - 2 - 3");
                }

                switch (option)
                {
                    case 1:
                        if (nameService == customers) AddCustomer(); else AddEmployee();
                        break;

                    case 2:
                        if (nameService == customers) UpdateCustomer(); else UpdateEmployee();
                        break;

                    case 3:
                        if (nameService == customers) RemoveCustomer(); else RemoveEmployee();
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        InvalidInput("0 - 1 - 2 - 3");
                        break;
                }
                Console.WriteLine("1 - Alta | 2 - Modificacion | 3 - Baja | 0 - Salir");
            }
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
                    InvalidInput("0 - 1 - 2 - 3 - 4 - 5 - 6");
                }

                switch (option)
                {
                    case 1:
                        ListCustomers();
                        break;

                    case 2:
                        ListEmployees();
                        break;

                    case 3:
                        ListCategories();
                        break;

                    case 4:
                        MenuABM("clientes");
                        break;

                    case 5:
                        MenuABM("empleados");
                        break;

                    case 6:
                        AddCategory();
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        InvalidInput("0 - 1 - 2 - 3 - 4 - 5 - 6");
                        break;
                }

                Continue();
                Console.ReadKey();
            }
        }

        public void MenuOptions()
        {
            Console.Clear();
            Console.WriteLine("MENU NORTHWIND");
            Console.WriteLine("1 - Listado de clientes");
            Console.WriteLine("2 - Listado de empleados");
            Console.WriteLine("3 - Listado de categorias");
            Console.WriteLine("4 - ABM de clientes");
            Console.WriteLine("5 - ABM de empleados");
            Console.WriteLine("6 - Alta de categorias");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Ingrese una opcion: ");
        }

        public void InvalidInput(string options)
        {
            Console.WriteLine($"Ingrese un caracter válido ({options})");
        }

        public void Continue()
        {
            Console.WriteLine("Pulse una tecla para continuar...");
        }
    }
}
