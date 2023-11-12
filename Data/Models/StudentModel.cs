using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Data.Models
{
    public class StudentModel
    {
        public string? groupName;
        public string? name;
        public string? surname;
        public int? age;
        public string? login;
        public string? password;

        public StudentModel( string? groupName, string? name, string? surname, int? age, string? login, string? password)
        {
            this.groupName = groupName;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.login = login;
            this.password = password;
        }
        public StudentModel(Student st)
        {
            groupName = st.GroupName;
            name = st.Name;
            surname = st.Surname;
            age = st.Age;
            login = st.Login;
            password = st.Password;
        }
    }
}
