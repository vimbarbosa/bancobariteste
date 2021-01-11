using System;
using Vini.Domain.Commands.Validations;

namespace Vini.Domain.Commands
{
    public class SendNewHelloCommand : HelloCommand 
    {
        public SendNewHelloCommand(string message)
        {
            Message = message;
        }

        public override bool IsValid()
        {
            ValidationResult = new SendNewHelloCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}