using System;
using System.IO;
using HelloCrowe.Core;
using HelloCrowe.Core.Models;
using HelloCrowe.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HelloCrowe.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);

            var services = new ServiceCollection();    

            if (!string.IsNullOrEmpty(environmentName))
            {
                builder.AddJsonFile($"appsettings.{environmentName}.json", optional: false, reloadOnChange: true);
            }

            var config = builder.AddEnvironmentVariables().Build();
        
            var environmentSettings = config.GetSection("MessageSource");
            services.Configure<MessageSource>(environmentSettings);

            var messageSource = new MessageSource();
            config.GetSection("MessageSource").Bind(messageSource);

            Console.WriteLine($"Are we using file system messages? {messageSource.UseFiles}");
            
            if (messageSource.UseFiles)
            {
                services.AddSingleton<IMessageRepository, FileBasedMessageRepository>();
            } else {
                services.AddSingleton<IMessageRepository, MessageRepository>();
            }
            
            services.AddSingleton<IMessageService, MessageService>();


            var serviceProvider = services.BuildServiceProvider();

            var messagService = serviceProvider.GetService<IMessageService>();
            var message = messagService.GetMessage();
            Console.WriteLine(message);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
