using System.Threading;
using WorkerService1.Src;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
         
            var testServ = new TestServ(stoppingToken);
            await testServ.WriteAsync();
            var tcs = new TaskCompletionSource<bool>();
            stoppingToken.Register(s=>((TaskCompletionSource<bool>)s).SetResult(true),tcs);
            await tcs.Task;
            await testServ.StopAsync(stoppingToken);
            //await task;
           
        }
    }
}