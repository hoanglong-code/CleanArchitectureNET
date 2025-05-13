using Infrastructure.Constants;
using Infrastructure.Exceptions.Extend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using ValidationException = Infrastructure.Exceptions.Extend.ValidationException;

namespace TestCoreBE.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.ExceptionHandled = true;
            _logger.LogError("ERROR", $"MESSAGE: {exception.Message}");

            string traceId = Activity.Current.Context.TraceId.ToString();

            switch (exception)
            {
                case BadRequestException badRequestValidation:
                    context.Result = new BadRequestObjectResult(new { ErrorCode = badRequestValidation.Code, Message = badRequestValidation.Message, TraceId = traceId });
                    context.ExceptionHandled = true;
                    break;
                case NotFoundException notFoundValidation:
                    context.Result = new NotFoundObjectResult(new { ErrorCode = notFoundValidation.Code, Message = notFoundValidation.Message, TraceId = traceId });
                    context.ExceptionHandled = true;
                    break;
                case ValidationException fluentValidation:
                    context.Result = new BadRequestObjectResult(new { ErrorCode = fluentValidation.Code, Message = fluentValidation.Message, Payloads = fluentValidation.Payloads, TraceId = traceId });
                    context.ExceptionHandled = true;
                    break;
                case PermisionException permisionException:
                    context.Result = new BadRequestObjectResult(new { ErrorCode = permisionException.Code, Message = permisionException.Message, Payloads = permisionException.Payloads, TraceId = traceId });
                    context.ExceptionHandled = true;
                    break;
                case UnauthorizedAccessException _:
                    context.Result = new BadRequestObjectResult(new { ErrorCode = ErrorCodeConstant.UN_AUTHORIZED, Message = MessageErrorConstant.AUTHORIZED, TraceId = traceId });
                    context.ExceptionHandled = true;
                    break;
                default:
                    context.Result = new BadRequestObjectResult(new { ErrorCode = ErrorCodeConstant.UNKNOWN_ERROR, Message = context.Exception.Message, TraceId = traceId });
                    break;
            }
        }
    }
}
