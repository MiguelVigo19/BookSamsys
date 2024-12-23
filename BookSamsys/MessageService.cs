public class MessageService : IMessageService
{
    public void Send(string queueName, string message)
    {
        // Lógica para enviar a mensagem
    }

    public List<string> Receive(string queueName, int maxMessages)
    {
        // Lógica para receber mensagens
        return new List<string>();
    }
}
