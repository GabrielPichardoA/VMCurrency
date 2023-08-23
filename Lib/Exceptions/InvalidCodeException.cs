namespace Lib.Exceptions
{
    public class InvalidCodeException : Exception
    {
        public InvalidCodeException() : base("Currency supplied is not valid.") { }

        public override string? StackTrace
        {
            get { return ""; }
        }
    }
}
