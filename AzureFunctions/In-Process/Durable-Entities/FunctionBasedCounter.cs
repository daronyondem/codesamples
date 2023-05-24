using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace Company.Function
{
    public static class FunctionBasedCounter
    {
        [FunctionName("FunctionBasedCounter")]
        public static void Counter([EntityTrigger] IDurableEntityContext ctx)
        {
            switch (ctx.OperationName.ToLowerInvariant())
            {
                case "add":
                    ctx.SetState(ctx.GetState<int>() + ctx.GetInput<int>());
                    break;
                case "reset":
                    ctx.SetState(0);
                    break;
                case "get":
                    ctx.Return(ctx.GetState<int>());
                    break;
                case "delete":
                    ctx.DeleteState();
                    break;
            }
        }
    }
}
