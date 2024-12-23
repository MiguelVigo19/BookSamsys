using System.Collections.Generic;

public interface IMessageService
    {
        void Send(string queueName, string message);
        List<string> Receive(string queueName, int maxMessages);

    }


