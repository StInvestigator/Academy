using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.UseCases
{
    public class GroupUseCase
    {
        public List<Group> groups;
        public GroupUseCase() 
        {
            groups = new List<Group>();
        }
        public void GetAllGroupsFromModel(IGroupRepository groupRepository)
        {
            groups = groupRepository.GetAll();
        }
    }
}
