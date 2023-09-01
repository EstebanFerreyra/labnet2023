using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Entities.DTO
{
    public class CustomersDTO
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set;}
        public string Address { get; set;}
        public string Phone { get; set;}
    }
}
