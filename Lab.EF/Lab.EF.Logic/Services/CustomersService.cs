using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Services
{
    public class CustomersService : BaseService, IABMServices<Customers>
    {
        public List<Customers> GetAll()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Add(Customers entity)
        {
            throw new NotImplementedException();
        }
       
        public void Update(Customers entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customers entity)
        {
            throw new NotImplementedException();
        }

    }
}
