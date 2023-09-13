using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Interfaces
{
    public interface IABMCustomers<T>
    {
        List<T> GetAll();
        T GetById(string id);
        bool Add(T entity);
        bool Delete(string id);
        bool Update(string id, string phone);
    }
}
