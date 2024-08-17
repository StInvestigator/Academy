
using Academy.DataBase;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Academy.Domain.Entities
{
    public class Group : INotifyPropertyChanged
    {
        public int Id { get; set; }
        string name;
        int year;
        int studentsCount;
        public string Name { get => name; set { name = value; NotifyPropertyChanged("Name"); } }
        public int Year { get => year; set { year = value; NotifyPropertyChanged("Year"); } }
        [NotMapped]
        public int StudentsCount { get => studentsCount; set { NotifyPropertyChanged("StudentsCount"); } }
        public void setStudentsCount()
        {
            AcademyContext academyContext = new AcademyContext();
            studentsCount = academyContext.Students.Where(x=>x.Group.Id==Id).Count();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
