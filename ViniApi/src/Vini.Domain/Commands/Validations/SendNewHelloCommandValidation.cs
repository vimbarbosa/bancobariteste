namespace Vini.Domain.Commands.Validations
{
    public class SendNewHelloCommandValidation : HelloValidation<SendNewHelloCommand>
    {
        public SendNewHelloCommandValidation()
        {
            ValidateMessage();
        }
    }
}