namespace HelloWebJobs.Services
{
    public interface IHelloService
    {
        Task<string> Replay(string message);
    }

    public class HelloService : IHelloService
    {
        public async Task<string> Replay(string message) 
            => await Task.FromResult(message);
    }
}
