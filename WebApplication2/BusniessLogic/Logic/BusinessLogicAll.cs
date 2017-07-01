using DataProvider.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using DataProvider.IProviders;

namespace BusinessLogic.Logic
{
    public  class BusinessLogicAll : IBusinessLogicAll
    {
        IUnitOfWork _uOfw { get; set; }
        public BusinessLogicAll(IUnitOfWork uOfw )
        {
            _uOfw = uOfw;
        }

        public void AddStory(Story item)
        {
          
            _uOfw.Stories.Create(item);
            _uOfw.Save();
        }

        public void AddGroup(Group item) ///
        {
            //  _uOfw.Groups.
          //  _uOfw.Save();
        }

        public void AddUser(User item)
        {
            _uOfw.Users.Create(item);
            _uOfw.Save();
        }

        public User GetUser(string Name)
        {
            var  user= _uOfw.Users.Get(Name);
            if (user == null)
            {
                /////////////  login chi exe
            }
            return user;
        }
        public IEnumerable<User> GetUsers()
        {
            return _uOfw.Users.GetAll();
        }
        public IEnumerable<Story> FindeStories(int id, int pageIndex, int count)
        {
            int startIndex = pageIndex * count;
            var list = _uOfw.Users.GetById(id).Stories.Skip(startIndex).Take(count).ToList();

            return list;
        }

        public IEnumerable<Group> FindeGroups( int pageIndex,int count)
        {
            int startIndex = pageIndex * count;
            int endIndex = pageIndex * count + count;
            return _uOfw.Groups.Find(p => p.Id > startIndex && p.Id < endIndex);
        }

        public Story FindeStory(int index)
        {
            return _uOfw.Stories.Get(index);
        }

        public void UpdateStory(Story item)
        {
            _uOfw.Stories.Update(item);
            _uOfw.Save();
        }
        public IEnumerable<Group> GetGroups()
        {
            return _uOfw.Groups.GetAll();
        }
        public int GetGroupUserCount(int index)
        {
            return _uOfw.Groups.Get(index).Users.Count;
        }

        public int GetGroupStoriesCount(int index)
        {
           return _uOfw.Groups.Get(index).Stories.Count;  // get Groups storiescolaction count
        }
        public    IEnumerable<string> GetGroupNames()
        {
            return _uOfw.Groups.GetAll().Select(u => u.Name).ToList();
        }
        public int GetGroupCount()
        {
            return _uOfw.Groups.GetCount();
        }
        public int GetStoriesCount(int id)
        {
            return _uOfw.Users.GetById(id).Stories.Count;
        }
    }
}
