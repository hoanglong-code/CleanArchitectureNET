using Infrastructure.Constants;
using Infrastructure.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Extend
{
    public class PermisionException : BaseException
    {
        public PermisionException(string message, Exception? innerException = null) : base(message, ErrorCodeConstant.PERMISION, innerException) { }
    }
}
