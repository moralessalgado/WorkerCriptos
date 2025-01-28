using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace WorkerCripto
{
    public class Library
    {
        public static async Task SendTelegramMessageAsync(string message)
        {
            var botToken = "7248773700:AAFJ7Cdxido0hgwPJC3I1B5L0fnTgzpYt4Q";
            var chatId = "305525672"; // Puede ser un ID de grupo o de usuario

            // Inicializar el cliente de Telegram
            var botClient = new TelegramBotClient(botToken);

            try
            {
                // Enviar mensaje
                var response = await botClient.SendMessage(
          chatId: chatId,
          text: message
        );

                Console.WriteLine($"Mensaje enviado con éxito: {response.MessageId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando el mensaje: {ex.Message}");
            }
        }
    }

    public class OpenInterestResponse
    {
        public string symbol { get; set; }
        public double value { get; set; }
        public int update { get; set; }
    }
}
