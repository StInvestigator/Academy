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
        public DateOnly? date {  get; set; }
        public string? workType { get; set; }
        public int? gradeNumber { get; set; }
        public string? studentLogin { get; set; }
        public string? lesson {  get; set; }

        public GradeModel(DateTime? Date, string? WorkType, int? Grade, string? Login, string? Lesson)
        {
            this.date = DateOnly.FromDateTime(Date??DateTime.Now);
            this.workType = WorkType;
            this.gradeNumber = Grade;
            this.studentLogin = Login;
            this.lesson = Lesson;
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
