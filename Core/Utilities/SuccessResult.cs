using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
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
