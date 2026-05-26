using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo.Business.Exceptions
{
    public class NotFoundException : Exception
    {
        public readonly string[] Errors;

        public NotFoundException(string error) : base(error)
        {
            Errors = [error];
        }

        public NotFoundException(string[] errors) : base(string.Join(", ", errors))
        {
            Errors = errors;
        }
    }
}
