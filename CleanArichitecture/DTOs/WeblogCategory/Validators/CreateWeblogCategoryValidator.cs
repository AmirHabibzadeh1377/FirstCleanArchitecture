using FluentValidation;

namespace CleanArichitecture.Application.DTOs.WeblogCategory.Validators
{
    public class CreateWeblogCategoryValidator:AbstractValidator<CreateWeblogCategoryDTOs>
    {
        public CreateWeblogCategoryValidator()
        {
            Include(new IWeblogCategoryValidator());
        }
    }
}