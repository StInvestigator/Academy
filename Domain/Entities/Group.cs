using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Group
    {
        string name;
        int year;
        public Group(string name, int year) 
        {
            this.name = name;
            this.year = year;
        }
        public string Name
        {
            get { return name; }
        }
        public int Year
        {
            get { return year; }    
            set { year = value; }
        }
        public void nextYear()
        {
            year++;
        }
    }
}
