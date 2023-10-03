using CleanArchitecture.Domain.Entities.Weblog;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Persistance.ServiceContract
{
    public interface IWeblogRepository:IGenericRepository<Weblog>
    {
    }
}