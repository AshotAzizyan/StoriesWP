using DataProvider.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using DataProvider.Context;

namespace DataProvider.Providers
{
    public class UserGroupProvider : IUserGroupProvider
    {
        private StoryContext _dbContex;
        public UserGroupProvider(StoryContext dbContext)
        {
            _dbContex = dbContext;
        }
        public IEnumerable<UserGroup> GetAll()
        {
           return _dbContex.UserGroups.ToList();
        }

        public UserGroup GetById(int id)
        {
            return _dbContex.UserGroups.Find(id);
        }

        public int GetCount(int groupId)
        {
            var result = _dbContex.UserGroups.Where(s=>s.GroupId==groupId).GroupBy(g => g.UserId).Select(o => o.Count() ).ToList().Count;
            return result;
        }
    }
}
