using FluentValidation;
using MagazineStore.Models.Requests;

namespace MagazineStore.Validators
{
    public class AddMagazineRequestValidator : AbstractValidator<AddMagazineRequest>
    {
        public AddMagazineRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(2);

            RuleFor(x => x.Year)
                .GreaterThan(1900).WithMessage("Year must be greater than 1900 lshfkjsd")
                .LessThan(2100);
        }
    }
}
