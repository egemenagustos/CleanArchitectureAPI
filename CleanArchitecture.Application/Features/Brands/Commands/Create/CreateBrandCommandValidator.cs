using FluentValidation;

namespace CleanArchitecture.Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is field must not be empty!")
                .MinimumLength(2).WithMessage("Name field must be at least 2 characters!");
        }
    }
}
