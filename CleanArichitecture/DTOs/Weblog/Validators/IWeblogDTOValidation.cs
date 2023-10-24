using CleanArichitecture.Application.Persistance.ServiceContract;
using FluentValidation;

namespace CleanArichitecture.Application.DTOs.Weblog.Validators
{
    public class IWeblogDTOValidation:AbstractValidator<IWeblogDTOs>
    {
        #region Fields 

        private readonly IWeblogCategoryRepository _weblogCategoryRepos;

        #endregion

        public IWeblogDTOValidation(IWeblogCategoryRepository weblogCategoryRepos)
        {
            _weblogCategoryRepos = weblogCategoryRepos;

            RuleFor(cw => cw.Name).NotEmpty().WithMessage("here for write error message")
                .NotNull()
                .MaximumLength(50).WithMessage("here for write error message");

            RuleFor(cw => cw.Slug)
                .NotEmpty().WithMessage("message...")
                .NotNull()
                .MaximumLength(60).WithMessage("message ...");

            RuleFor(cw => cw.WeblogCategoryId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    bool exists = await _weblogCategoryRepos.IsExist(id);
                    return exists;
                }).WithMessage("message ...");
        }
    }
}