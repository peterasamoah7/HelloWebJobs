using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace HelloWebJobs.Functions
{
    public class StudentFunction
    {
        public StudentFunction() { }

        public async Task ProcessBlob([BlobTrigger("student")]Stream blob, ILogger logger)
        {
            logger.LogInformation(blob.Length.ToString());
            await Task.Delay(500);
        }
    }
}
