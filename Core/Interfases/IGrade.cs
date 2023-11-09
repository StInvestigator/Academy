using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Interfases
{
    interface IGrade
    {
        DateTime Date { get; set; }
        string WorkType { get; set; }
        int GradeNumber { get; set; }
    }
}
