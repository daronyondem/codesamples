using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionFilters
{
    public class ErrorHandlerAttribute : FunctionExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(
            FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
            // custom error handling logic could be written here
            // (e.g. write a queue message, send a notification, etc.)

            exceptionContext.Logger.LogError(
                $"ErrorHandler called. Function '{exceptionContext.FunctionName}" +
                ":{exceptionContext.FunctionInstanceId} failed.");

            return Task.CompletedTask;
        }
    }
}
