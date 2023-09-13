using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Services
{
    public class CustomersService : BaseService, IABMCustomers<Customers>
    {
        public List<Customers> GetAll()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Ocurrio un error al buscar la lista de clientes: {exe.Message}");
                return null;
            }
        }
  
        public Customers GetById(string id)
        {
            try
            {
                return _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error: {exe.Message}");
                return null;
            }
        }

        public bool Add(Customers entity)
        {
            try
            {
                _context.Customers.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Ocurrio un error al intentar agregar un cliete: {exe.Message}");
                return false;
            }
        }
       
        public bool Update(string id, string phone)
        {
            try
            {
                Customers customersUpdate = _context.Customers.First(c => c.CustomerID == id);
                if (customersUpdate != null)
                {
                    customersUpdate.Phone = phone;
                    _context.SaveChanges();
                    Console.WriteLine("Cliente modificado con exito");
                    return true;
                }
                return false;
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Ocurrio un error al intentar modificar un cliete: {exe.Message}");
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                Customers customerDelete = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
                if (customerDelete != null)
                {
                    _context.Customers.Remove(customerDelete);
                    _context.SaveChanges();
                    Console.WriteLine("Cliente eliminado con exito");
                    return true;
                }
                return false;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                Console.WriteLine("Esta intentando borrar una entidad que tiene una FK a otra tabla");
                return false;
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Ocurrio un error al intentar borrar un cliete: {exe.Message} {exe.GetType()}");
                return false;
            }
        }
    }
}
