using HelloCrowe.Core;
using HelloCrowe.Core.Models;
using HelloCrowe.Services;
using NUnit.Framework;
using Microsoft.Extensions.Options;

namespace HelloCrowe.Tests
{   
    [TestFixture] 
    public class MessageServiceTests
    {
        private IMessageRepository _messageRepository;

        [SetUp]
        public void Setup()
        {
            _messageRepository = new MessageRepository();
        }

        [Test]
        public void When_Using_Default_Repository_Messages_Exist()
        {
            var service = new MessageService(_messageRepository);

            var message = service.GetMessage();

            Assert.AreEqual(message, "Hello World", "Default messages are equal to Hello World");
        }

        [Test]
        public void When_Using_FileBased_Repository_Messages_Exist()
        {
            var options = Options.Create<MessageSource>(new MessageSource() { FileName = "test.txt", FilePath = "Assets" });

            var fileBasedMessageRepository = new FileBasedMessageRepository(options);
            var service = new MessageService(fileBasedMessageRepository);

            var message = service.GetMessage();

            Assert.AreEqual(message, "Hello World (from file)", "File-based messages are equal to Hello World (from file)");
        }
    }
}
