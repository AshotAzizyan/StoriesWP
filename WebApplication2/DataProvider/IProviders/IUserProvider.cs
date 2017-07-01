using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.IProviders
{
    public interface IUserProvider
    {
        IEnumerable<User> GetAll();
        User  Get(string name);
        User GetById(int id);
        void Create(User item);
        
    }
}
