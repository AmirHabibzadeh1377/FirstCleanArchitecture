using CleanArichitecture.Application.Persistance.ServiceContract;
using FluentValidation;

namespace CleanArichitecture.Application.DTOs.Weblog.Validators
{
    public class UpdateWeblogDTOValidator:AbstractValidator<UpdateWeblogDTOs>
    {
        #region Fields

        private readonly IWeblogCategoryRepository _weblogCategoryRepo;

        #endregion
        public UpdateWeblogDTOValidator(IWeblogCategoryRepository weblogCategoryRepo)
        {
            _weblogCategoryRepo = weblogCategoryRepo;
            Include(new IWeblogDTOValidation(_weblogCategoryRepo));
            RuleFor(w => w.ID).NotNull().WithMessage("Id is reuqierd");
        }
    }
}
