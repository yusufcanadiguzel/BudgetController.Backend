using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(isSuccess: false)
        {
        }

        public ErrorResult(string message) : base(message: message, isSuccess: false)
        {
        }
    }
}
