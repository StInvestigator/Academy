using Academy.Data.Models;
using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System.Collections.Generic;

namespace Academy.Data.Repositories
{
    public class GroupRepository : IRepository<Group>
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
                    item.year ?? 1,
                    item.studentsCount ?? 0
                    ));
            }
            return groups;
        }
    }
}
