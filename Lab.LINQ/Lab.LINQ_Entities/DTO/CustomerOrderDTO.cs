using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ_Entities.DTO
{
    public class CustomerOrderDTO
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
