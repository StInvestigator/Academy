using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Data.Models
{
    public class GradeModel
    {
        public DateOnly? date;
        public string? workType;
        public int? gradeNumber;
        public string? studentLogin;
        public string? lesson;
        public GradeModel(DateOnly? date, string? workType, int? GradeNumber, string? studentLogin, string? lesson)
        {
            this.date = date;
            this.workType = workType;
            this.gradeNumber = GradeNumber;
            this.studentLogin = studentLogin;
            this.lesson = lesson;
        }
        public GradeModel(Grade g)
        {
            date = g.Date;
            workType = g.WorkType;
            gradeNumber = g.GradeNumber;
            studentLogin = g.StudentLogin;
            lesson = g.Lesson;
        }
    }
}
