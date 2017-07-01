using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.IProviders
{
    public interface IProvider<T>
    {
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T Get(int id);
        IEnumerable<T> GetAll();
        int GetCount();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
