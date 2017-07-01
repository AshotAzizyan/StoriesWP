using DataModel.Models;
using DataProvider.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public interface IBusinessLogicAll
    {
        void AddStory(Story item);//
        void AddGroup(Group item);//
        void AddUser(User item); // bl i meja sargum user u generacnum sax
        User GetUser(string Name);
        IEnumerable<User> GetUsers();
        IEnumerable<Group> GetGroups();//
        int GetGroupCount();//
        int GetStoriesCount(int id);//
        IEnumerable<Story> FindeStories(int userId, int pageIndex ,int count);// // 
        IEnumerable<Group> FindeGroups(int pageIndex,int count); //
        Story FindeStory(int index);//
        void UpdateStory(Story item);//
        IEnumerable<string> GetGroupNames();//
        int GetGroupUserCount(int index);//
        int GetGroupStoriesCount(int index);//

    }
}
