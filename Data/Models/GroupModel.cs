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
        public GroupModel(string? name, int? year)
        {
            this.name = name;
            this.year = year;
        }
        public GroupModel(Group gr)
        {
            name = gr.Name;
            year = gr.Year;
        }
    }
}
