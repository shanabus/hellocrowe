using System.Linq;
using HelloCrowe.Core;

namespace HelloCrowe.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;   
        }

        public string GetMessage() 
        {
            return _messageRepository.Get().FirstOrDefault();
        }

        public void SendMessage(string message)
        {

        }
    }
}