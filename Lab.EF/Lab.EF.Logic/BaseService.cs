using Lab.EF.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public abstract class BaseService
    {
        protected readonly NorthwindContext _context;

        public BaseService()
        {
            _context = new NorthwindContext();
        }
    }
}
