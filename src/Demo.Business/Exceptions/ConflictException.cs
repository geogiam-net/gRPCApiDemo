using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo.Business.Exceptions
{
    public class ConflictException : Exception
    {
        public readonly string[] Errors;

        public ConflictException(string error) : base(error)
        {
            Errors = [error];
        }

        public ConflictException(string[] errors) : base(string.Join(", ", errors))
        {
            Errors = errors;
        }
    }
}
