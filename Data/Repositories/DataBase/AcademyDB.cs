using Academy.Core.Constants;
using Academy.Data.Models;
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
        static string connectionString = @"Data Source=DESKTOP-OF66R01\SQLEXPRESS;Initial Catalog=FinalAcademy;Integrated Security=True;Trust Server Certificate=True";
        public static List<GradeModel> GetGrades()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<GradeModel>("").ToList();
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
    }
}
