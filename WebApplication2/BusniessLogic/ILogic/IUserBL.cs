using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniessLogic.ILogic
{
    public interface IUserBL
    {
        void AddUser(User item); 
        User GetUser(string Name);
        IEnumerable<User> GetUsers();
    }
}
