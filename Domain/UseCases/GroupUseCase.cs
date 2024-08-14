using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System.Collections.Generic;

namespace Academy.Domain.UseCases
{
    public class GroupUseCase
    {
        public List<Group> groups;
        public GroupUseCase() 
        {
            groups = new List<Group>();
        }
        public void GetAllGroupsFromModel(IRepository<Group> groupRepository)
        {
            groups = groupRepository.GetAll();
        }

        public void AddGroup(string name, int year)
        {
            AcademyDB.insertGroup(name, year);
        }
        public void UpdateGroup(string newName, int year, string oldName)
        {
            AcademyDB.updateGroup(newName, year, oldName);
        }
        public void DeleteGroup(string name)
        {
            AcademyDB.deleteGroup(name);
        }
    }
}
