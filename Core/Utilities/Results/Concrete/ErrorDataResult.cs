using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data: data, isSuccess: false)
        {
        }

        public ErrorDataResult(T data, string message) : base(data: data, message: message, isSuccess: false)
        {
        }
    }
}
