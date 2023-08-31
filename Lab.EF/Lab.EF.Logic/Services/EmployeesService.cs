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
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Add(Employees entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Employees entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employees entity)
        {
            throw new NotImplementedException();
        }
    }
}
