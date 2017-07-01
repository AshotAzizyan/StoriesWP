using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniessLogic.ILogic
{
    public interface IStoryBL
    {
        void AddStory(Story item);
        int GetStoriesCount(int id);
        IEnumerable<Story> FindeStories(int userId, int pageIndex, int count);
        Story FindeStory(int index);
        void UpdateStory(Story item);
        IEnumerable<Group> GetGroups();
    }
}
