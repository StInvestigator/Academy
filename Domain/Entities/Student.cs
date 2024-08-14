

namespace Academy.Domain.Entities
{
    public class Student : Human
    {
        string groupName;

        public Student(string login,string password, string name, string surname, int age, string groupName) : base(name,surname,age,login,password)
        {
            this.groupName = groupName;
        }
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; NotifyPropertyChanged("GroupName"); } 
        }
    }
}
