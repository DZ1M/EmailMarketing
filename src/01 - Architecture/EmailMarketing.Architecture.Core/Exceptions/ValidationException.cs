using FluentValidation.Results;

namespace EmailMarketing.Architecture.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
        public static void ThrowException(string propertyName, string message)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(propertyName, message) };
            throw new ValidationException(failures);
        }
    }
}
