namespace BookSamsys.DTO
{
    public class MessagingHelperDTO
    {
        
        public void SendMessage(MessageDTO messageDto)
        {
            try
            {
                // Simula a lógica de envio de uma mensagem
                Console.WriteLine($"Mensagem enviada com Sucesso  : {messageDto.Message}");
                messageDto.Success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar mensagem: {ex.Message}");
                messageDto.Success= false;  
            }
        }

        public IEnumerable<string> ReceiveMessages(string queueName, int maxMessages = 10)
        {
            try
            {
                // Simula a lógica de recebimento de mensagens
                Console.WriteLine($"Recebendo até {maxMessages} mensagens da fila {queueName}");
                return new List<string> { "Mensagem1", "Mensagem2", "Mensagem3" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao receber mensagens: {ex.Message}");
                return new List<string>();
            }
        }
    }
}