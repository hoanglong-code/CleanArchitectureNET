﻿using Infrastructure.Constants;
using Infrastructure.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Extend
{
    [Serializable]
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message, Exception? innerException = null) : base(message, ErrorCodeConstant.BAD_REQUEST, innerException) { }
    }
}
