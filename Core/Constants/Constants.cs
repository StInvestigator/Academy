
namespace Academy.Core.Constants
{
    public static class Constants
    {
        public const string AdminLogin = "admin";
        public const string AdminPassword = "nimda";

        public const string TeacherLogin = "teacher";
        public const string TeacherPassword = "rehcaet";

        public const string StudentLogin = "student";
        public const string StudentPassword = "tneduts";

        public const string GetStudents = @"select g.Name as GroupName,s.Name,s.Surname,s.Age,s.Login,s.Password from Students s join Groups g on s.GroupId = g.Id";
    }
}
