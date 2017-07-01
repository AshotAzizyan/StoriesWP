using BusniessLogic.ILogic;
using DataProvider.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;

namespace BusniessLogic.Logic
{
    public class UserGroupBL: IUserGroupBL
    {
        IUnitOfWork _uOfw { get; set; }
        public UserGroupBL(IUnitOfWork uOfw)
        {
            _uOfw = uOfw;
        }

        public IEnumerable<UserGroup> GetAllUserGroup()
        {
            return _uOfw.UserGroups.GetAll();
        }

        public UserGroup GetUserGroupById(int id)
        {
            return _uOfw.UserGroups.GetById(id);
        }

        public IEnumerable<int> GetUserGroupCount(IEnumerable<Group> groupIds)
        {
            var countsUser=new List<int> ();
            foreach (var item in groupIds)
            {
                var result = _uOfw.UserGroups.GetCount(item.Id);
                countsUser.Add(result);
            }
            return countsUser;
        }
    }
}
