using HelloWebJobs.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace HelloWebJobs.Functions
{
    public class HelloFunction
    {
        private readonly IHelloService _helloService;

        public HelloFunction(IHelloService helloService)
        {
            _helloService = helloService;
        }

        public async Task ProcessQueueMessage([QueueTrigger("hello")]string message, ILogger logger)
        {
            var result = await _helloService.Replay(message.ToString());
            logger.LogInformation(result);
        }
    }
}
