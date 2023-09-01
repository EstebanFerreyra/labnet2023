using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Services
{
    public class EmployeesService : BaseService, IABMServices<Employees>
    {
        public List<Employees> GetAll()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Ocurrio un error al buscar la lista de empleados: {exe.Message}");
                return null;
            }
        }

        public Employees GetById(string id)
        {
            int idParse = Int32.Parse(id);
            try
            {
                return _context.Employees.FirstOrDefault(e => e.EmployeeID == idParse);
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Error: {exe.Message}");
                return null;
            }
        }

        public void Add(Employees entity)
        {
            try
            {
                _context.Employees.Add(entity);
                _context.SaveChanges();
                Console.WriteLine("Empleado agregado con exito");
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Ocurrio un error al intentar agregar un empleado: {exe.Message}");
            }
        }

        public bool Update(string id, string phone)
        {
            int idParse = Int32.Parse(id);
            try
            {
                Employees employeesUpdate = _context.Employees.FirstOrDefault(e => e.EmployeeID == idParse);
                if (employeesUpdate != null)
                {
                    employeesUpdate.HomePhone = phone;
                    _context.SaveChanges();
                    Console.WriteLine("Empleado modificado con exito");
                    return true;
                }
                return false;
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Ocurrio un error al intentar modificar un empleado: {exe.Message}");
                return false;
            }
        }

        public bool Delete(string id)
        {
            int idParse = Int32.Parse(id);
            try
            {
                Employees employeeDelete = _context.Employees.FirstOrDefault(e => e.EmployeeID == idParse);
                if (employeeDelete != null)
                {
                    _context.Employees.Remove(employeeDelete);
                    _context.SaveChanges();
                    Console.WriteLine("Empleado borrado con exito");
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
                Console.WriteLine($"Error al intentar borrar un empleado: {exe.Message}");
                return false;
            }
        }
    }
}
