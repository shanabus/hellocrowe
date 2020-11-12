using System;
using HelloCrowe.Core;
using HelloCrowe.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HelloCrowe.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IMessageRepository, MessageRepository>()
                .AddSingleton<IMessageService, MessageService>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting...");

            var messagService = serviceProvider.GetService<IMessageService>();

            var message = messagService.GetMessage();

            Console.WriteLine("Hello World\r\n");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
