using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Lesson
    {
        public string name {  get; set; }
        public Lesson(string name)
        {
            this.name = name;
        }
    }
}
