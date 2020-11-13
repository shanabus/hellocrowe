using System;

namespace HelloCrowe.Services
{
    public interface IMessageService
    {
        string GetMessage();

        void SetMessage(string message);
    }
}
