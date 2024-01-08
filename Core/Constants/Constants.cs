
namespace Academy.Core.Constants
{
    public static class Constants
    {
        public const string AdminLogin = "admin";
        public const string AdminPassword = "nimda";

        public const string GetGrades = @"select g.Date,g.WorkType,g.Grade,s.Login,l.Name as Lesson from Grades g join Students s on g.StudentId=s.Id join Lessons l on l.Id = g.LessonId";
        public const string GetStudents = @"select g.Name as GroupName,s.Name,s.Surname,s.Age,s.Login,s.Password from Students s join Groups g on s.GroupId = g.Id";
        public const string GetGroups = @"select Name, Year from Groups";
        public const string GetSchedule = @"select Date date, t.Name teacherName,t.Surname teacherSurname,g.Name groupName,Class class,l.Name as lesson from Schedules s join Teachers t on s.TeacherId=t.Id join Groups g on g.Id=s.GroupId join Lessons l on l.Id=s.LessonId";
        public const string GetTasks = @"select t.Desctiption desctiption, t.WorkType type, l.Name lesson, t.Date termin, s.Login studentLogin,t.IsDone isDone from Tasks t join Lessons l on t.LessonId=l.Id join Students s on t.StudentId=s.Id";
        public const string GetTeachers = @"select Name name, Surname surname, Age age, Login login, Password password from Teachers";
        public const string GetLessons = @"select name from Lessons";

        public const string InsertGrade = @"insert into Grades(Date,WorkType,Grade,LessonId,StudentId) values(@Date,@WorkType,@Grade,(select Id from Lessons where Name = @Lesson),(select Id from Students where Login = @Student))";
        public const string InsertTask = @"insert into Tasks(Desctiption,WorkType,LessonId,StudentId,Date,IsDone) values(@Desctiption,@WorkType,(select Id from Lessons where Name = @Lesson),(select Id from Students where Login = @Student),@Termin,0)";
        public const string InsertStudent = @"insert into Students(Name,Surname,Age,Login,Password,GroupId) values(@Name,@Surname,@Age,@Login,@Password,(select Id from Groups where Name = @Group))";
        public const string InsertTeacher = @"insert into Teachers(Name,Surname,Age,Login,Password) values(@Name,@Surname,@Age,@Login,@Password)";
        public const string InsertSchedule = @"";

        public const string UpdateStudent = @"update Students set Name=@Name, Surname=@Surname, Age=@Age, Login=@Login, Password=@Password, GroupId=(select Id from Groups where Name = @Group) where Login=@Src";
        public const string UpdateTeacher = @"update Teachers set Name=@Name, Surname=@Surname, Age=@Age, Login=@Login, Password=@Password where Login=@Src";
        public const string UpdateSchedule = @"";

        public const string DeleteStudent = @"delete from Students where Login=@Src";
        public const string DeleteTeacher = @"delete from Teachers where Login=@Src";
        public const string DeleteSchedule = @"";
    }
}
