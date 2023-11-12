using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Task
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string Lesson { get; set; }
        public DateTime Termin { get; set; }
        public Task(string desctiption, string type, string lesson, DateTime termin)
        {
            Description = desctiption;
            Type = type;
            Lesson = lesson;
            Termin = termin;
        }
    }
}
