using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Data.Models
{
    public class LessonModel
    {
        public string? name { get; set; }
        public LessonModel(string? name)
        {
            this.name = name;
        }
    }
}
