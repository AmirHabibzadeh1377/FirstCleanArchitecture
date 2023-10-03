using FluentValidation;

namespace CleanArichitecture.Application.DTOs.WeblogCategory.Validators
{
    public class UpdateWeblogCategoryValidator:AbstractValidator<UpdateWeblogCategoryDTOs>
    {
        public UpdateWeblogCategoryValidator()
        {
            Include(new IWeblogCategoryValidator());
            RuleFor(wc => wc.ID)
                .NotNull().WithMessage("id is required");
        }
    }
}