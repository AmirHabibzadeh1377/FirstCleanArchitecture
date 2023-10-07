using CleanArchitecture.Domain.Entities.Weblog;
using CleanArichitecture.Application.Persistance.ServiceContract;

namespace CleanArchitecture.Persistence.Repositories
{
    public class WeblogRepository:GenericRepository<Weblog>, IWeblogRepository
    {
        #region Fields

        private readonly CleanArchitecture_DBContext _context;

        #endregion

        #region Ctor

        public WeblogRepository(CleanArchitecture_DBContext context) : base(context)
        {
            _context = context;
        }

        #endregion
    }
}