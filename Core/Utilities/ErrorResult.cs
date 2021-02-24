using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
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
