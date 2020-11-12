using HelloCrowe.Core;
using HelloCrowe.Services;
using NUnit.Framework;

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
        public void When_No_Messages_Exist()
        {
            var service = new MessageService(_messageRepository);

            var message = service.GetMessage();

            Assert.AreEqual(message, "Hello World", "Default messages are equal to Hello World");
        }
    }
}
