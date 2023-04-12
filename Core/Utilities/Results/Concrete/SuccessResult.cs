using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(isSuccess: true)
        {
        }

        public SuccessResult(string message) : base(message: message, isSuccess: true)
        {
        }
    }
}
