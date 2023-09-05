using Lab.LINQ_Data.Context;
using Lab.LINQ_Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.UI
{
    public class ProgramMenu
    {
        private readonly CustomersService _customersService;
        private readonly ProductsService _productsService;
        private readonly CategoriesService _categoriesService;

        public ProgramMenu(CustomersService customersService, ProductsService productsService, CategoriesService categoriesService) 
        {
            _customersService = customersService;
            _productsService = productsService;
            _categoriesService = categoriesService;
        }

        public void ListCustomers()
        {
            var listCustomers = _customersService.GetAll();
            if (listCustomers == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                ShowCustomers(listCustomers);
            }
        }

        public void ListProductNonStock()
        {
            var listProducts = _productsService.GetProductsNonStock();
            if (listProducts == null)
            {
                Console.WriteLine("Lista vacia o error");
            }else
            {
                ShowProducts(listProducts);
            }
        }

        public void ListProductsStockAndPriceGreatThan3()
        {
            var listProducts = _productsService.GetProductsStockAndPriceGreatThan3();
            if (listProducts == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                ShowProducts(listProducts);
            }
        }

        public void ListCustomersRegionWA()
        {
            var listCustomers = _customersService.GetAllCustomersRegionWA();
            if (listCustomers == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                ShowCustomers(listCustomers);
            }
        }

        public void ProductById()
        {
            var product = _productsService.GetProductsById(789);
            if (product == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                Console.WriteLine($"Id: {product.ProductID} | Producto: {product.ProductName} | Precio: {product.UnitPrice}");
            }
        }

        public void ListCustomersMm()
        {
            var listCustomers = _customersService.GetAll();
            if (listCustomers == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                foreach (var item in listCustomers)
                {
                    Console.WriteLine($"Id: {item.CustomerID} | Nombre: {item.ContactName} | Compania: {item.CompanyName}");
                    Console.WriteLine($"Id: {item.CustomerID.ToUpper()} | Nombre: {item.ContactName.ToUpper()} | Compania: {item.CompanyName.ToUpper()}");
                }
            }
        }

        public void ListCustomerOrder()
        {
            var listCustomersOrder = _customersService.GetCustomerOrders();
            if (listCustomersOrder == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                foreach (var item in listCustomersOrder)
                {
                    Console.WriteLine($"Id Order: {item.OrderID} | Id Cliente: {item.CustomerID} | Nombre: {item.ContactName} | FechaOrden: {item.OrderDate}");
                }
            }
        }

        public void ListTop3CustomersRegionWA()
        {
            var listCustomers = _customersService.GetTop3CustomersRegionWA();
            if (listCustomers == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                foreach (var item in listCustomers)
                {
                    Console.WriteLine($"Id: {item.CustomerID} | Nombre: {item.ContactName} | Compania: {item.CompanyName}");
                }
            }
        }

        public void ListProductsOrderByName()
        {
            var listProducts = _productsService.GetProductsOrderByName();
            if (listProducts == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                ShowProducts(listProducts);
            }
        }

        public void ListProductsOrderByUnitInStock()
        {
            var listProducts = _productsService.GetProductsOrderByUnitInStock();
            if (listProducts == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                ShowProducts(listProducts);
            }
        }

        public void ListCategories()
        {
            var listCategories = _categoriesService.GetCategories();
            if (listCategories == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                foreach (var item in listCategories)
                {
                    Console.WriteLine($"Id: {item.CategoryID} | Nombre: {item.CategoryName} | Descripcion: {item.Description}");
                }
            }
        }

        public void Product()
        {
            var product = _productsService.GetProduct();
            if (product == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                Console.WriteLine($"Id: {product.ProductID} | Producto: {product.ProductName} | Precio: {product.UnitPrice}");

            }
        }

        public void ListCountOrderCustomer()
        {
            var listCountOrderCustomers = _customersService.GetCountOrderCustomer();
            if (listCountOrderCustomers == null)
            {
                Console.WriteLine("Lista vacia o error");
            }
            else
            {
                foreach (var item in listCountOrderCustomers)
                {
                    Console.WriteLine($"Nombre: {item.ContactName} | Catntidad ordenes: {item.CountOrder}");
                }
            }
        }
        
        public void ShowCustomers(List<Customers> list)
        {
            foreach(Customers item in list)
            {
                Console.WriteLine($"Id: {item.CustomerID} | Nombre: {item.ContactName} | Compania: {item.CompanyName}");
            }
        }

        public void ShowProducts(List<Products> list)
        {
            foreach (Products item in list)
            {
                Console.WriteLine($"Id: {item.ProductID} | Producto: {item.ProductName} | Precio: {item.UnitPrice}");
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
                    InvalidInput("0 - 1 - 2 - 3 - 4 - 5 - 6 - 7 - 8 - 9 - 10 - 11 - 12 - 13");
                }

                switch (option)
                {
                    case 1:
                        ListCustomers();
                        break;

                    case 2:
                        ListProductNonStock();
                        break;

                    case 3:
                        ListProductsStockAndPriceGreatThan3();
                        break;

                    case 4:
                        ListCustomersRegionWA();
                        break;

                    case 5:
                        ProductById();
                        break;

                    case 6:
                        ListCustomersMm();
                        break;

                    case 7:
                        ListCustomerOrder();
                        break;

                    case 8:
                        ListTop3CustomersRegionWA();
                        break;

                    case 9:
                        ListProductsOrderByName();
                        break;

                    case 10:
                        ListProductsOrderByUnitInStock();
                        break;

                    case 11:
                        ListCategories();
                        break;

                    case 12:
                        Product();
                        break;
                    case 13:
                        ListCountOrderCustomer();
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        InvalidInput("0 - 1 - 2 - 3 - 4 - 5 - 6 - 7 - 8 - 9 - 10 - 11 - 12 - 13");
                        break;
                }

                Continue();
                Console.ReadKey();
            }
        }

        public void MenuOptions()
        {
            Console.Clear();
            Console.WriteLine("MENU CONSULTAS");
            Console.WriteLine("1 - Lista clientes");
            Console.WriteLine("2 - Lista productos sin stock");
            Console.WriteLine("3 - Lista productos con stock y que cuestan mas que 3");
            Console.WriteLine("4 - Clientes de la region WA");
            Console.WriteLine("5 - Producto con id 789");
            Console.WriteLine("6 - Nombre de clientes");
            Console.WriteLine("7 - Clientes de region WA y fecha de order mayor a 1/1/1997");
            Console.WriteLine("8 - Lista 3 primeros clientes de la region WA");
            Console.WriteLine("9 - Lista de productos ordenados por el nombre");
            Console.WriteLine("10 - Lista de productos ordenados por UnitInStock");
            Console.WriteLine("11 - Lista de categorias asociadas a los productos");
            Console.WriteLine("12 - Primer elemento de la lista productos");
            Console.WriteLine("13 - Lista de clientes y la cantidad de ordenes asociadas");
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
