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
    public class StoryBL:IStoryBL
    {
        IUnitOfWork _uOfw { get; set; }
        public StoryBL(IUnitOfWork uOfw)
        {
            _uOfw = uOfw;
        }
        public void AddStory(Story item)
        {
            _uOfw.Stories.Create(item);
            _uOfw.Save();
        }
        public int GetStoriesCount(int id)
        {
            return _uOfw.Users.GetById(id).Stories.Count;
        }
        public IEnumerable<Story> FindeStories(int id, int pageIndex, int count)
        {
            int startIndex = pageIndex * count;
            var list = _uOfw.Users.GetById(id).Stories.Skip(startIndex).Take(count).ToList();

            return list;
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

    }
}
