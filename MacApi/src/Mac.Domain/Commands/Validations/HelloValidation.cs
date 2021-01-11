using FluentValidation;

namespace Mac.Domain.Commands.Validations
{
    public abstract class HelloValidation<T> : AbstractValidator<T> where T : HelloCommand
    {
        protected void ValidateMessage()
        {
            RuleFor(c => c.Message)
                .NotEmpty().WithMessage("Please ensure you have entered the Message")
                .Length(2, 150).WithMessage("The Message must have between 2 and 150 characters");
        }
    }
}