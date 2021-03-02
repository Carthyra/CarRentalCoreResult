namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
            // sadece mesaj
        }

        public ErrorResult() : base(false)
        {
            // hiç bir şey
        }
    }
}
