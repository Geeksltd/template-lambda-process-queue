using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Olive;

namespace App
{
    public class Function : Olive.Aws.Function<Startup>
    {
        static readonly string QueueUrl = Config.Get("EventBus:Queue");
        static EventBusQueue<QueueMessage> Queue => EventBus.Queue<QueueMessage>(QueueUrl);

        public override async Task ExecuteAsync(ILambdaContext context)
        {
            Log.Info("Processed: " + await ProcessAll());
        }

        async Task<int> ProcessAll()
        {
            var done = 0;

            await Queue.PullAll(async x =>
            {
                await x.Process();
                done++;
            });

            return done;
        }
    }
}