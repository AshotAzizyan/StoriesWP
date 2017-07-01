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
    public class GroupProvider : IProvider<Group>
    {
        private StoryContext _dbContex;
        public GroupProvider(StoryContext dbContex)
        {
            _dbContex = dbContex;
        }
        public void Create(Group item)
        {
            _dbContex.Groups.Add(item);
        }
        public void Update(Group item)
        {
            _dbContex.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            var item = _dbContex.Groups.Find(id);
            if (item != null)
            {
                _dbContex.Groups.Remove(item);
            }
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
             return _dbContex.Groups.Where(predicate).ToList();
        }

        public Group Get(int id)
        {
          return   _dbContex.Groups.Include(o => o.Stories).Include(g => g.Users).SingleOrDefault(x => x.Id == id); 
        }

        public IEnumerable<Group> GetAll()
        {
            return _dbContex.Groups.ToList();
        }
         public  int GetCount()
        {
            return _dbContex.Groups.Count();
        }

    }
}
