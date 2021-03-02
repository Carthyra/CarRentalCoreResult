namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {
            // sadece mesaj.
        }

        public SuccessResult() : base(true)
        {
            // hiç bir şey.
        }
    }
}
