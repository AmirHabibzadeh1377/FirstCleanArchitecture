using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Persistance.ServiceContract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> Get();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
