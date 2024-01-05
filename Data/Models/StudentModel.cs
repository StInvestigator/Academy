using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Data.Models
{
    public class StudentModel
    {
        public string? GroupName {  get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public StudentModel( string? groupName, string? name, string? surname, int? age, string? login, string? password)
        {
            this.GroupName = groupName;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Login = login;
            this.Password = password;
        }
        public StudentModel(Student st)
        {
            GroupName = st.GroupName;
            Name = st.Name;
            Surname = st.Surname;
            Age = st.Age;
            Login = st.Login;
            Password = st.Password;
        }
    }
}
