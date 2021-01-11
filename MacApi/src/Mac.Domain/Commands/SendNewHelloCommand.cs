using System;
using Mac.Domain.Commands.Validations;

namespace Mac.Domain.Commands
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