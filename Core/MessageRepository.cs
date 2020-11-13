namespace HelloCrowe.Core
{
    public class MessageRepository : IMessageRepository
    {
        private string _message = "Hello World";

        // While this is currently a static repository, it could easily be a facade for EF or similar ORM
        public string Get() 
        {
            return _message;
        }

        public void Set(string message)
        {
            _message = message;
        }
    }
}