using DataModel.Models;
using DataProvider.Context;
using DataProvider.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Providers
{
    public class StoryProvider : IProvider<Story>
    {
        private StoryContext _dbContex;
        public StoryProvider(StoryContext dbContex)
        {
            _dbContex = dbContex;
        }
        public void Create(Story item)
        {
            _dbContex.Stories.Add(item);
            _dbContex.UserGroups.Add(new UserGroup() { GroupId=item.GroupId, UserId=item.UserId });
        }
        public void Update(Story item)
        {
            _dbContex.Entry(item).State = System.Data.Entity.EntityState.Modified;
           var ug=  _dbContex.UserGroups.Find(item.Id);
            _dbContex.Entry(ug).State = System.Data.Entity.EntityState.Modified;
            ug.GroupId = item.GroupId;
            ug.UserId = item.UserId;
        }
        public void Delete(int id)
        {
            var item=_dbContex.Stories.Find(id);
            if (item!=null )
            {
                _dbContex.Stories.Remove(item);
            }
            
        }

        public IEnumerable<Story> Find(Func<Story, bool> predicate)
        {
            return _dbContex.Stories.Where(predicate).ToList();
        }

        public Story Get(int id)
        {
            return _dbContex.Stories.Find(id);
        }

        public IEnumerable<Story> GetAll()
        {
           return _dbContex.Stories.ToList();

        }

        public int GetCount()
        {
            return _dbContex.Stories.Count(); 
        }
    }
}
