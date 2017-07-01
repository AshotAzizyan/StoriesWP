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
    public class GroupBL: IGroupBL
    {
        IUnitOfWork _uOfw { get; set; }
        public GroupBL(IUnitOfWork uOfw)
        {
            _uOfw = uOfw;
        }
        public void AddGroup(Group item) 
        {
            _uOfw.Groups.Create(item);
            _uOfw.Save();
        }
        public IEnumerable<Group> FindeGroups(int pageIndex, int count)
        {
            int startIndex = pageIndex * count;
            int endIndex = pageIndex * count + count;
            return _uOfw.Groups.Find(p => p.Id > startIndex && p.Id < endIndex);
        }
        public IEnumerable<Group> GetGroups()
        {
            return _uOfw.Groups.GetAll();
        }
        public IEnumerable<int> GetGroupStoriesCount(IEnumerable<Group> groups)
        {
            var storyCounts = new List<int>();
            foreach (var item in groups)
            {
                var h= item.Stories.Count;
                storyCounts.Add(item.Stories.Count);
            }

            return storyCounts; 
        }
        public int GetGroupCount()
        {
            return _uOfw.Groups.GetCount();
        }
    }
}
