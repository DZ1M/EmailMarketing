using FluentValidation.Results;

namespace EmailMarketing.Architecture.Core.Messages
{
    public class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; set; }
        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
