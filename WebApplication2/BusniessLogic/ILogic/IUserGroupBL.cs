using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniessLogic.ILogic
{
    public interface IUserGroupBL
    {
        IEnumerable<UserGroup> GetAllUserGroup();
        UserGroup GetUserGroupById(int id);
        IEnumerable<int> GetUserGroupCount(IEnumerable<Group> groupIds);
    }
}
