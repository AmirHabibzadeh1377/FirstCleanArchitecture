using CleanArichitecture.Application.Persistance.ServiceContract;
using FluentValidation;

namespace CleanArichitecture.Application.DTOs.Weblog.Validators
{
    public class CreateWeblogDTOValidator:AbstractValidator<CreateWeblogDTOs>
    {
        #region Fields 

        private readonly IWeblogCategoryRepository _weblogCategoryRepo;

        #endregion
        public CreateWeblogDTOValidator(IWeblogCategoryRepository weblogCategoryRepo)
        {
            _weblogCategoryRepo = weblogCategoryRepo;
            Include(new IWeblogDTOValidation(_weblogCategoryRepo));
        }
    }
}
