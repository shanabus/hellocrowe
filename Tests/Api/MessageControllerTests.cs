using HelloCrowe.Core;
using HelloCrowe.Services;
using HelloCrowe.Api.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace HelloCrowe.Tests.Api
{
    [TestFixture]
    public class MessageControllerTests
    {
        private IMessageRepository _messageRepository;
        private IMessageService _messageService;

        [SetUp]
        public void Setup()
        {
            _messageRepository = new MessageRepository();
            _messageService = new MessageService(_messageRepository);
        }

        [Test]
        public void When_Get_Using_Default_Repository()
        {
            var controller = new MessagesController(null, _messageService);

            var result = (OkObjectResult)controller.Get();

            Assert.AreEqual(result.Value, "Hello World");
            Assert.AreEqual(result.StatusCode, 200);
        }

        [Test]
        public void When_Post_Using_Default_Repository()
        {
            var controller = new MessagesController(null, _messageService);

            var result = (OkResult)controller.Post("sample message");

            Assert.AreEqual(result.StatusCode, 200);
        }
    }
}