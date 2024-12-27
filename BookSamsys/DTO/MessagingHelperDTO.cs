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


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar mensagem: {ex.Message}");

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

        public bool  ValidateMessage(MessageDTO messageDto)
        {
            if (string.IsNullOrWhiteSpace(messageDto.Message))
            {
                Console.WriteLine("A mensagem não pode estar vazia.");
                return messageDto.Success = false;
            }
                if (messageDto.Message.Length > 256)
                {
                    Console.WriteLine("A mensagem excede o tamanho permitido.");
                    return messageDto.Success = false;
                }
                else
                {
                Console.WriteLine("Validação confirmada.");
                    return messageDto.Success=true ;
                }
            }
        }





    }
