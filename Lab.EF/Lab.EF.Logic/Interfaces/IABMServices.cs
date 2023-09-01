using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Interfaces
{
    public interface IABMServices<T>
    {
        List<T> GetAll();
        T GetById(string id);
        void Add(T entity);
        bool Delete(string id);
        bool Update(string id, string phone);
    }
}
