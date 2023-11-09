using Academy.Core.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Academy.Domain.Entities
{
    struct Grade : IGrade
    {
        DateTime date;
        string workType;
        int grade;
        public DateTime Date { get => date; set => date = value; }
        public string WorkType { get => workType; set => workType = value; }
        int IGrade.GradeNumber { get => grade; set => grade = value; }
    }
}
