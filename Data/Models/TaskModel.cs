using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;

namespace Academy.Data.Models
{
    public class TaskModel
    {
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Lesson { get; set; }
        public DateOnly? Termin { get; set; }
        public string? StudentLogin { get; set; }
        public bool? isDone { get; set; }
        public TaskModel(string? desctiption, string? type, string? lesson, DateOnly? termin, string? studentLogin, bool? isDone)
        {
            Description = desctiption;
            Type = type;
            Lesson = lesson;
            Termin = termin;
            StudentLogin = studentLogin;
            this.isDone = isDone;
        }
        public TaskModel(Task t)
        {
            Description = t.Description;
            Type = t.Type;
            Lesson = t.Lesson;
            Termin = t.Termin;
            StudentLogin = t.StudentLogin;
        }
    }
}
