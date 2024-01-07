using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Repositories
{
    public interface ILessonRepository
    {
        public List<Lesson> GetAll();
    }
}
