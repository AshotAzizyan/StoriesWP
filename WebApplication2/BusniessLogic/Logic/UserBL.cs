using BusniessLogic.ILogic;
using DataModel.Models;
using DataProvider.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniessLogic.Logic
{
    public class UserBL: IUserBL
    {
        IUnitOfWork _uOfw { get; set; }
        public UserBL(IUnitOfWork uOfw)
        {
            _uOfw = uOfw;
        }
        public void AddUser(User item)
        {
            _uOfw.Users.Create(item);
            _uOfw.Save();
        }

        public User GetUser(string Name)
        {
            return _uOfw.Users.Get(Name);
        }
        public IEnumerable<User> GetUsers()
        {
            return _uOfw.Users.GetAll();
        }
    }
}
