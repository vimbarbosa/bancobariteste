namespace Mac.Domain.Commands.Validations
{
    public class SendNewHelloCommandValidation : HelloValidation<SendNewHelloCommand>
    {
        public SendNewHelloCommandValidation()
        {
            ValidateMessage();
        }
    }
}