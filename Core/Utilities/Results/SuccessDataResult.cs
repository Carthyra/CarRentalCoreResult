namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
            // data + mesaj.
        }

        public SuccessDataResult(T data) : base(data, true)
        {
            // data
        }

        public SuccessDataResult(string message) : base(default, true,message)
        {
            // mesaj.
        }

        public SuccessDataResult() : base(default, true)
        {
            // hiç bir şey verme.
        }
    }
}
