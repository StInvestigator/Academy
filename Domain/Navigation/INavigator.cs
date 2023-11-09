using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Navigation
{
    public interface INavigator
    {
        void UtilizeState(object state);
    }
}
