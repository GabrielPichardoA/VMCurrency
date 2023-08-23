namespace Lib.Exceptions
{
    public class AmountExceedsLimitException : Exception
    {
        public AmountExceedsLimitException() : base("Amount attempted exceed the monthly limit allowed. Please try with a lower amount.") { }

        public override string? StackTrace
        {
            get { return ""; }
        }
    }
}
