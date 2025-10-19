using Microsoft.Extensions.Options;
using ServiceExpress.Application.Common;
using ServiceExpress.Application.Configurations;
using ServiceExpress.Application.Interfaces;
using ServiceExpress.Domain;
using ServiceExpress.Infrastructure.Interfaces;
using ServiceExpress.Infrastructure.Persistence;
using System.Text.Json;

namespace ServiceExpress.Application.Services
{
    public class WhatsAppWebHookService : IWhatsAppWebHookService
    {
        private readonly WhatsAppWebHookSettings _settings;
        private readonly IRegistroConversacionRepository _registroConversacionRepository;

        public WhatsAppWebHookService(IOptions<WhatsAppWebHookSettings> options, IRegistroConversacionRepository registroConversacionRepository)
        {
            _settings = options.Value;
            _registroConversacionRepository = registroConversacionRepository;
        }

        public void RecieveData(WebhookMessageRequest data)
        {
            //var json = JsonDocument.Parse(data);
            //var objectType = json.RootElement.GetProperty("object").GetString();
            Console.WriteLine($"Payload: {data.ToString()}");

            //var json = JsonSerializer.Deserialize<string>(data) ?? string.Empty;


            //var request = JsonSerializer.Deserialize<WebhookMessageRequest>(json) ?? new WebhookMessageRequest();
            ProcessData(data);

        }

        public Result<int> VerificateRequest(string mode, int challenge, string veryfyToken)
        {
            var token = _settings.VerifyToken;  

            if (mode == "subscribe" && veryfyToken == token)
            {
                return Result<int>.Success(challenge);
            }

            return Result<int>.Forbidden("");
        }

        private async void ProcessData(WebhookMessageRequest request)
        {
            var response = await _registroConversacionRepository.GetAllAsync(); //Validar en BD si el numero de telefono ya realizo solicitud antes
            Console.WriteLine("Procesando datos del webhook...");
            response.AsParallel().ForAll(x => Console.WriteLine(x.ToString()));
        }

        private void HandlerSnedMessage() { }
        private void SendMessage()
        {
            //Llamar a la API de WhatsApp para enviar mensaje

        }
    }
}
