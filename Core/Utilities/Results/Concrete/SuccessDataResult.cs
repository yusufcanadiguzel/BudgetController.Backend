﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data: data, isSuccess: true)
        {
        }

        public SuccessDataResult(T data, string message) : base(data: data, message: message, isSuccess: true)
        {
        }
    }
}
