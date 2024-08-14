using System.Collections.Generic;

namespace Academy.Domain.Repositories
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
    }
}
