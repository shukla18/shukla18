using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCTestingApp.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAll();

        Task<IEnumerable<T>> FindByName(string name);

        Task<IEnumerable<T>> FindById(int id);

        Task<bool> Add(T entity);

        Task<bool> Update(T entity);

        Task Delete(int id);

    }
}
