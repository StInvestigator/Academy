using Academy.Core.Constants;
using Academy.Data.Models;
using Academy.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Academy.Data.Repositories.DataBase
{
    public static class AcademyDB
    {
        const string connectionString = @"Data Source=DESKTOP-OF66R01\SQLEXPRESS;Initial Catalog=FinalAcademy;Integrated Security=True;Trust Server Certificate=True";
        public static List<GradeModel> GetGrades()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<GradeModel>(Constants.GetGrades).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return new List<GradeModel>();
                
            }
        }
        public static List<StudentModel> GetStudents()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<StudentModel>(Constants.GetStudents).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return new List<StudentModel>();
            }
        }
        public static List<TeacherModel> GetTeachers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<TeacherModel>(Constants.GetTeachers).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return new List<TeacherModel>();
            }
        }
        public static List<GroupModel> GetGroups()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<GroupModel>(Constants.GetGroups).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return new List<GroupModel>();
            }
        }
        public static List<ScheduleModel> GetSchedules()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<ScheduleModel>(Constants.GetSchedule).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return new List<ScheduleModel>();
            }
        }
        public static List<TaskModel> GetTasks()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<TaskModel>(Constants.GetTasks).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return new List<TaskModel>();
            }
        }
        public static List<LessonModel> GetLessons()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<LessonModel>(Constants.GetLessons).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return new List<LessonModel>();
            }
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
        public static void insertGrade(DateTime date, string workType, int grade, string lesson, string studentLogin)
        {
            object[] parameters = { new { Date = date, WorkType = workType, Grade = grade, Lesson = lesson, Student = studentLogin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.InsertGrade, parameters);
            }
        }
        public static void insertTask(string desctiption, string workType, string lesson, string studentLogin, DateTime termin)
        {
            object[] parameters = { new { Desctiption = desctiption, WorkType = workType, Lesson = lesson, Student = studentLogin, Termin = termin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.InsertTask, parameters);
            }
        }
        public static void markTask(string desctiption, DateTime termin, string studentLogin)
        {
            object[] parameters = { new { Desc = desctiption, Login = studentLogin, Date = termin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.MarkTaskDone, parameters);
            }
        }
        public static void unmarkTask(string desctiption, DateTime termin, string studentLogin)
        {
            object[] parameters = { new { Desc = desctiption, Login = studentLogin, Date = termin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.MarkTaskUndone, parameters);
            }
        }
        public static void deleteTask(string desctiption, DateTime termin, string studentLogin)
        {
            object[] parameters = { new { Desc = desctiption, Login = studentLogin, Date = termin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.DeleteTask, parameters);
            }
        }
        public static void insertStudent(string name, string surname, int age, string login, string password, string groupName)
        {
            object[] parameters = { new { Name = name, Surname = surname, Age = age, Login = login, Password = password, Group = groupName } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.InsertStudent, parameters);
            }
        }
        public static void updateStudent(string name, string surname, int age, string login, string password, string groupName, string srcLogin)
        {
            object[] parameters = { new { Name = name, Surname = surname, Age = age, Login = login, Password = password, Group = groupName, Src = srcLogin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.UpdateStudent, parameters);
            }
        }
        public static void deleteStudent(string srcLogin)
        {
            object[] parameters = { new {Src = srcLogin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.DeleteStudent, parameters);
            }
        }
        public static void insertTeacher(string name, string surname, int age, string login, string password)
        {
            object[] parameters = { new { Name = name, Surname = surname, Age = age, Login = login, Password = password } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.InsertTeacher, parameters);
            }
        }
        public static void updateTeacher(string name, string surname, int age, string login, string password, string srcLogin)
        {
            object[] parameters = { new { Name = name, Surname = surname, Age = age, Login = login, Password = password, Src = srcLogin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.UpdateTeacher, parameters);
            }
        }
        public static void deleteTeacher(string srcLogin)
        {
            object[] parameters = { new { Src = srcLogin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.DeleteTeacher, parameters);
            }
        }
        public static void insertSchedule(DateTime date, string @class, string teacherLogin, string groupName, string lesson)
        {
            object[] parameters = { new { Date = date, Class = @class, Teacher = teacherLogin, Group = groupName, Lesson = lesson } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.InsertSchedule, parameters);
            }
        }
        public static void updateSchedule(DateTime date, string @class, string teacherLogin, string groupName, string lesson, int id)
        {
            object[] parameters = { new { Date = date, Class = @class, Teacher = teacherLogin, Group = groupName, Lesson = lesson, Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.UpdateSchedule, parameters);
            }
        }
        public static void deleteSchedule(int id)
        {
            object[] parameters = { new { Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.DeleteSchedule, parameters);
            }
        }
        public static void deleteGrade(Grade gr)
        {
            object[] parameters = { new { Date = gr.Date.ToDateTime(TimeOnly.MinValue), Type = gr.WorkType, Grade = gr.GradeNumber, Lesson = gr.Lesson,Login = gr.StudentLogin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.DeleteGrade, parameters);
            }
        }
        public static void insertLesson(string lesson)
        {
            object[] parameters = { new { Lesson = lesson } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.InsertLesson, parameters);
            }
        }
        public static void updateLesson(string lesson,string oldName)
        {
            object[] parameters = { new { Lesson = lesson, Name = oldName } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.UpdateLesson, parameters);
            }
        }
        public static void deleteLesson(string lesson)
        {
            object[] parameters = { new { Lesson = lesson } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.DeleteLesson, parameters);
            }
        }
    }
}
