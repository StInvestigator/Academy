using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Data.Models
{
    public class ScheduleModel
    {
        public DateTime? Date { get; set; }
        public string? TeacherName { get; set; }
        public string? TeacherSurname { get; set; }
        public string? GroupName { get; set; }
        public string? Class { set; get; }
        public string? Lesson { set; get; }
        public ScheduleModel(DateTime? date, string? teacherName,string? teacherSurname, string? groupName, string? @class, string? lesson)
        {
            Date = date ?? DateTime.Now;
            TeacherName = teacherName;
            TeacherSurname = teacherSurname;
            GroupName = groupName;
            Class = @class;
            Lesson = lesson;
        }
        public ScheduleModel(Schedule sch)
        {
            Date = sch.Date;
            TeacherName = sch.TeacherName;
            TeacherSurname = sch.TeacherSurname;
            GroupName = sch.GroupName;
            Class = sch.Class;
            Lesson = sch.Lesson;
        }
    }
}
