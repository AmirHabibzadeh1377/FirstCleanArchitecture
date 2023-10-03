using FluentValidation;

namespace CleanArichitecture.Application.DTOs.WeblogCategory.Validators
{
    public class IWeblogCategoryValidator:AbstractValidator<IWeblogCategoryDTOs>
    {
        public IWeblogCategoryValidator()
        {
            RuleFor(wc => wc.Slug).NotEmpty()
                .WithMessage("message place...")
                .MaximumLength(200).WithMessage("message place");
        }
    }
}