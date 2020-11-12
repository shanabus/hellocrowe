using System;

namespace HelloCrowe.Core
{
    public interface IMessageRepository
    {
        string[] Get();

        void Set(string message);
    }
}
