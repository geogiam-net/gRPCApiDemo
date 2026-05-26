namespace Demo.Business.Exceptions
{
    public class ValidationException : Exception
    {
        public readonly string[] Errors;

        public ValidationException(string error) : base(error)
        {
            Errors = [error];
        }

        public ValidationException(string[] errors) : base(string.Join(", ", errors))
        {
            Errors = errors;
        }
    }
}
