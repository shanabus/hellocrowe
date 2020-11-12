using System;

namespace HelloCrowe.Services
{
    public interface IMessageService
    {
        string GetMessage();

        void SendMessage(string message);
    }
}
