using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Data.Models
{
    public class GroupModel
    {
        public string? name;
        public int? year;
        public int? studentsCount;
        public GroupModel(string? Name, int? Year, int? StudentsCount)
        {
            name = Name;
            year = Year;
            studentsCount = StudentsCount;
        }
        public GroupModel(Group gr)
        {
            name = gr.Name;
            year = gr.Year;
            studentsCount = gr.StudentsCount;
        }
    }
}
