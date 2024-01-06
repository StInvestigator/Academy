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
        public static void insertGrade(DateTime date, string workType, int grade, string lesson, string studentLogin)
        {
            object[] parameters = { new { Date = date, WorkType = workType, Grade = grade, Lesson = lesson, Student = studentLogin } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(Constants.InsertGrade, parameters);
            }
        }
    }
}
