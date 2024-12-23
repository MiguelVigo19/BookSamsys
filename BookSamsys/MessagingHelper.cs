public class MessagingHelper
{
    private readonly IMessageService _messageService;

    public MessagingHelper(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void SendMessage(string queueName, string message)
    {
        try
        {
            _messageService.Send(queueName, message);
        }
        catch (Exception ex)
        {
            // Tratamento de exceção
        }
    }

    public IEnumerable<string> ReceiveMessages(string queueName, int maxMessages = 10)
    {
        try
        {
            return _messageService.Receive(queueName, maxMessages);
        }
        catch (Exception ex)
        {
            // Tratamento de exceção
            return new List<string>();
        }
    }
}
