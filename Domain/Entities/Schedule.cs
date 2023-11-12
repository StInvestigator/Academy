using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Schedule
    {
        public DateOnly DateOnly { get; set; }
        public TimeOnly TimeOnly { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string GroupName { get; set; }
        public string Class { set; get; }
        public string Lesson { set; get; }
        public Schedule(DateOnly dateOnly, TimeOnly timeOnly, string teacherName, string teacherSurname, string groupName, string @class, string lesson)
        {
            DateOnly = dateOnly;
            TimeOnly = timeOnly;
            TeacherName = teacherName;
            TeacherSurname = teacherSurname;
            GroupName = groupName;
            Class = @class;
            Lesson = lesson;
        }
    }
}
