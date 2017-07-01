using DataModel.Models;
using DataProvider.Context;
using DataProvider.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataProvider.Providers
{
    public class UserProvider: IUserProvider
    {
        private StoryContext _dbContex;
        public UserProvider(StoryContext dbContext)
        {
            _dbContex = dbContext;
        }
        public void Create(User item)
        {
            _dbContex.Users.Add(item);
        }
        public User Get(string name)
        {
            return _dbContex.Users.Where(u => u.Name == name).FirstOrDefault();
        }
        public User GetById(int id)
        {
            return _dbContex.Users.Include(o => o.Stories).SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<User> GetAll()
        {
            return _dbContex.Users;
        }

        //public int PostStory(Story story)
        //{
        //    return 0;// db context
        //}
    }
}
