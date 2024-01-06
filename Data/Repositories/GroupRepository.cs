using Academy.Data.Models;
using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        List<GroupModel> _groups;
        public GroupRepository()
        {
            _groups = new List<GroupModel>();

            foreach (var item in AcademyDB.GetGroups())
            {
                _groups.Add(item);
            }
        }
        public List<Group> GetAll()
        {
            List<Group> groups = new List<Group>();
            foreach (var item in _groups)
            {
                groups.Add(new Group(
                    item.name ?? "Group1",
                    item.year ?? 1
                    ));
            }
            return groups;
        }
    }
}
