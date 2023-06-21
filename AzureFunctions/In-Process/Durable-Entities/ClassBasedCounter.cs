using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Newtonsoft.Json;

namespace Company.Function
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ClassBasedCounter
    {
        public ClassBasedCounter()
        {
            Value = 0;
        }
        
        [JsonProperty]
        public int Value { get; set; }

        public void Add(int amount) 
        {
            this.Value += amount;
        }

        public Task Reset() 
        {
            this.Value = 0;
            return Task.CompletedTask;
        }

        public Task<int> Get() 
        {
            return Task.FromResult( this.Value);;
        }

        public void Delete() 
        {
            Entity.Current.DeleteState();
        }

        [FunctionName(nameof(ClassBasedCounter))]
        public static Task Run([EntityTrigger] IDurableEntityContext ctx)
            => ctx.DispatchAsync<ClassBasedCounter>();
    }
}