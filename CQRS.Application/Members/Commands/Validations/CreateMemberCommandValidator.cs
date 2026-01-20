using FluentValidation;

namespace CQRS.Application.Members.Commands.Validations
{
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Please ensure you have entered the FirstName")
                .Length(4, 100).WithMessage("The FirstName must have between 4 and 100 chacarters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Please ensure you have entered the LastName")
                .Length(4, 100).WithMessage("The LastName must have between 4 and 100 chacarters");

            RuleFor(x => x.Gender)
               .NotEmpty()
               .MinimumLength(4)
               .Length(4, 100).WithMessage("The gender must be a valid information");

            RuleFor(x => x.Email)
               .NotEmpty()
               .EmailAddress();

            RuleFor(x => x.Active)
               .NotNull();
        }
    }
}
