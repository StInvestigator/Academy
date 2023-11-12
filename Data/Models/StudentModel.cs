using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Data.Models
{
    public class StudentModel
    {
        public List<Grade>? grades;
        public string? groupName;
        public string? name;
        public string? surname;
        public int? age;
        public string? login;
        public string? password;

        public StudentModel(List<Grade>? grades, string? groupName, string? name, string? surname, int? age, string? login, string? password)
        {
            this.grades = grades ?? new List<Grade>();
            this.groupName = groupName;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.login = login;
            this.password = password;
        }
        public StudentModel(Student st)
        {
            grades = st.grades;
            groupName = st.GroupName;
            name = st.Name;
            surname = st.Surname;
            age = st.Age;
            login = st.Login;
            password = st.Password;
        }
    }
}
