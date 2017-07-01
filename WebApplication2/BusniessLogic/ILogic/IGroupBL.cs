using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniessLogic.ILogic
{
    public interface IGroupBL
    {
        void AddGroup(Group item);
        IEnumerable<Group> GetGroups();
        int GetGroupCount();
        IEnumerable<Group> FindeGroups(int pageIndex, int count);
        IEnumerable<int> GetGroupStoriesCount(IEnumerable<Group> groups);
    }
}
