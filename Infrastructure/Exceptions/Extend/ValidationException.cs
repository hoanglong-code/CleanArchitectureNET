using Infrastructure.Constants;
using Infrastructure.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Extend
{
    [Serializable]
    public class ValidationException : BaseException
    {
        public ValidationException(string message, Exception? innerException = null) : base(message, ErrorCodeConstant.VALIDATION, innerException) { }
        public ValidationException(string message, IDictionary<string, object> payloads, Exception? innerException = null)
            : base(message, ErrorCodeConstant.VALIDATION, payloads, innerException) { }
    }
}
