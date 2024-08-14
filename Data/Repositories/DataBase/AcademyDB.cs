using Academy.Core.Constants;
using Academy.Data.Models;
using Academy.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Academy.Data.Repositories.DataBase
{
    public static class AcademyDB
    {
        const string connectionString = @"Data Source=DESKTOP-OF66R01\SQLEXPRESS;Initial Catalog=FinalAcademy;Integrated Security=True;Trust Server Certificate=True";

        static List<T> getTList<T>(string sql) where T : class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<T>(sql).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return new List<T>();
            }
        }
        public static List<GradeModel> GetGrades()
        {
            return getTList<GradeModel>(Constants.GetGrades);
        }
        public static List<StudentModel> GetStudents()
        {
            return getTList<StudentModel>(Constants.GetStudents);
        }
        public static List<TeacherModel> GetTeachers()
        {
            return getTList<TeacherModel>(Constants.GetTeachers);
        }
        public static List<GroupModel> GetGroups()
        {
            return getTList<GroupModel>(Constants.GetGroups);
        }
        public static List<ScheduleModel> GetSchedules()
        {
            return getTList<ScheduleModel>(Constants.GetSchedule);
        }
        public static List<TaskModel> GetTasks()
        {
            return getTList<TaskModel>(Constants.GetTasks);
        }
        public static List<LessonModel> GetLessons()
        {
            return getTList<LessonModel>(Constants.GetLessons);
        }
        public static int GetShceduleIdByNum(int num)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<int>(Constants.GetScheduleId).ElementAt(num);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return -1;
            }
        }

        static void executeSQL(string sql, object[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, parameters);
            }
        }
        public static void insertGrade(DateTime Date, string WorkType, int Grade, string Lesson, string studentLogin)
        {
            executeSQL(Constants.InsertGrade, new[] { new { Date, WorkType, Grade, Lesson, Student = studentLogin } });
        }
        public static void insertTask(string Desctiption, string WorkType, string Lesson, string studentLogin, DateTime Termin)
        {
            executeSQL(Constants.InsertTask, new[] { new { Desctiption, WorkType, Lesson, Student = studentLogin, Termin } });
        }
        public static void markTask(string desctiption, DateTime termin, string studentLogin)
        {
            executeSQL(Constants.MarkTaskDone, new[] { new { Desc = desctiption, Login = studentLogin, Date = termin } });
        }
        public static void unmarkTask(string desctiption, DateTime termin, string studentLogin)
        {
            executeSQL(Constants.MarkTaskUndone, new[] { new { Desc = desctiption, Login = studentLogin, Date = termin } });
        }
        public static void deleteTask(string desctiption, DateTime termin, string studentLogin)
        {
            executeSQL(Constants.DeleteTask, new[] { new { Desc = desctiption, Login = studentLogin, Date = termin } });
        }
        public static void insertStudent(string Name, string Surname, int Age, string Login, string Password, string groupName)
        {
            executeSQL(Constants.InsertStudent, new[] { new { Name, Surname, Age, Login, Password, Group = groupName } });
        }
        public static void updateStudent(string Name, string Surname, int Age, string Login, string Password, string groupName, string srcLogin)
        {
            executeSQL(Constants.UpdateStudent, new[] { new { Name, Surname, Age, Login, Password, Group = groupName, Src = srcLogin } });
        }
        public static void deleteStudent(string srcLogin)
        {
            executeSQL(Constants.DeleteStudent, new[] { new { Src = srcLogin } });
        }
        public static void insertTeacher(string Name, string Surname, int Age, string Login, string Password)
        {
            executeSQL(Constants.InsertTeacher, new[] { new { Name, Surname, Age, Login, Password } });
        }
        public static void updateTeacher(string Name, string Surname, int Age, string Login, string Password, string srcLogin)
        {
            executeSQL(Constants.UpdateTeacher, new[] { new { Name, Surname, Age, Login, Password, Src = srcLogin } });
        }
        public static void deleteTeacher(string srcLogin)
        {
            executeSQL(Constants.DeleteTeacher, new[] { new { Src = srcLogin } });
        }
        public static void insertSchedule(DateTime Date, string Class, string teacherLogin, string groupName, string Lesson)
        {
            executeSQL(Constants.InsertSchedule, new[] { new { Date, Class, Teacher = teacherLogin, Group = groupName, Lesson } });
        }
        public static void updateSchedule(DateTime Date, string Class, string teacherLogin, string groupName, string Lesson, int Id)
        {
            executeSQL(Constants.UpdateSchedule, new[] { new { Date, Class, Teacher = teacherLogin, Group = groupName, Lesson, Id } });
        }
        public static void deleteSchedule(int Id)
        {
            executeSQL(Constants.DeleteSchedule, new[]{ new { Id } });
        }
        public static void deleteGrade(Grade gr)
        {
            executeSQL(Constants.DeleteGrade, new[] { new { Date = gr.Date.ToDateTime(TimeOnly.MinValue), Type = gr.WorkType, Grade = gr.GradeNumber, Lesson = gr.Lesson, Login = gr.StudentLogin } });
        }
        public static void insertLesson(string Lesson)
        {
            executeSQL(Constants.InsertLesson, new[] { new { Lesson } });
        }
        public static void updateLesson(string Lesson,string oldName)
        {
            executeSQL(Constants.UpdateLesson, new[] { new { Lesson, Name = oldName } });
        }
        public static void deleteLesson(string Lesson)
        {
            executeSQL(Constants.DeleteLesson, new[] { new { Lesson } });
        }
        public static void insertGroup(string Name, int Year)
        {
            executeSQL(Constants.InsertGroup, new[] { new { Name, Year } });
        }
        public static void updateGroup(string newName, int Year, string oldName)
        {
            executeSQL(Constants.UpdateGroup, new[] { new { newName, Year, Name = oldName } });
        }
        public static void deleteGroup(string Name)
        {
            executeSQL(Constants.DeleteGroup, new[] { new { Name } }) ;
        }
    }
}
