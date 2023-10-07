using CleanArchitecture.Domain.Entities.Weblog;
using CleanArichitecture.Application.Persistance.ServiceContract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class WeblogCategoryRepository:GenericRepository<WeblogCategory>, IWeblogCategoryRepository
    {
        #region Fields

        private readonly CleanArchitecture_DBContext _context;

        #endregion

        #region Ctor

        public WeblogCategoryRepository(CleanArchitecture_DBContext context):base(context)
        {
            _context = context;
        }

        #endregion


        public async Task<bool> IsExist(int weblogCategoryId)
        {
            var weblogCategory = _context.WeblogCategories.FirstOrDefaultAsync(w => w.ID == weblogCategoryId);
            return weblogCategory != null;
        }
    }
}