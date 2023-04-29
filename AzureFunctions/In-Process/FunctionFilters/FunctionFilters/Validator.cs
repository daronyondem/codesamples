using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionFilters
{
    public class Validator : FunctionInvocationFilterAttribute
    {
        public override Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            var name = ((Microsoft.AspNetCore.Http.HttpRequest)executingContext.Arguments.First().Value).Query["name"].ToString();

            if (name.Length < 3)
            {
                throw new Exception();
            }

            return base.OnExecutingAsync(executingContext, cancellationToken);
        }

        public override Task OnExecutedAsync(FunctionExecutedContext executedContext, CancellationToken cancellationToken)
        {
            return base.OnExecutedAsync(executedContext, cancellationToken);
        }
    }
}
