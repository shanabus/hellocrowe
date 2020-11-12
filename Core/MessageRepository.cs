
namespace HelloCrowe.Core
{
    public class MessageRepository : IMessageRepository
    {
        public string[] Get() 
        {
            return new string[] { "Hello World" };
        }

        public void Set(string message)
        {

        }
    }
}