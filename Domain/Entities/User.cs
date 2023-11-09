using Academy.Core.Interfases;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Academy.Domain.Entities
{
    internal class User : IUser
    {
        string login;
        string password;

        public User()
        {
            login = string.Empty;
            password = "";
        }
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}