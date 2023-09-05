using Lab.LINQ_Data.Context;
using Lab.LINQ_Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ_Logic.Services
{
    public class CustomersService : BaseService
    {
        public List<Customers> GetAll()
        {
			try
			{
				return _context.Customers.ToList();
			}
			catch (Exception exe)
			{
                Console.WriteLine($"Error al encontrar lista de clientes: {exe.Message}");
                return null;
			}
        }

        public List<Customers> GetAllCustomersRegionWA()
        {
			try
			{
                return _context.Customers
                    .Where(c => c.Region == "WA")
                    .ToList();
			}
			catch (Exception exe)
			{
                Console.WriteLine($"Error al encontrar lista de clientes de la region WA: {exe.Message}");
                return null;
            }
        }

        public List<Customers> GetTop3CustomersRegionWA()
        {
            try
            {
                return _context.Customers
                    .Where(c => c.Region == "WA")
                    .Take(3)
                    .ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al encontrar lista de clientes de la region WA: {exe.Message}");
                return null;
            }
        }

        public List<CustomerOrderDTO> GetCustomerOrders()
        {
            try
            {
                var orderQuery = from customer in _context.Customers
                        join order in _context.Orders
                        on customer.CustomerID equals order.CustomerID
                        where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                        select new CustomerOrderDTO
                        {
                            CustomerID = customer.CustomerID,
                            ContactName = customer.ContactName,
                            OrderID = order.OrderID,
                            OrderDate = order.OrderDate
                        };

                return orderQuery.ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al hacer join entre Customers y Orders: {exe.Message}");
                return null;
            }
        }

        public List<CountOrderCustomer> GetCountOrderCustomer()
        {
            try
            {
                var countOrderCustomer = 
                    from customer in _context.Customers
                    join order in _context.Orders on customer.CustomerID equals order.CustomerID
                    group customer by new
                    {
                        customer.CustomerID,
                        customer.CompanyName
                    } into customerGroup
                    select new CountOrderCustomer
                    {
                        ContactName = customerGroup.Key.CompanyName,
                        CountOrder = customerGroup.Count()
                    };

                return countOrderCustomer.ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error al hacer join entre Customers y Orders: {exe.Message}");
                return null;
            }
        }
    }
}
