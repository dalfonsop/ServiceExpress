using Microsoft.Extensions.Options;
using ServiceExpress.Application.Common;
using ServiceExpress.Application.Configurations;
using ServiceExpress.Application.Interfaces;

namespace ServiceExpress.Application.Services
{
    public class WhatsAppWebHookService : IWhatsAppWebHookService
    {
        private readonly WhatsAppWebHookSettings _settings;

        public WhatsAppWebHookService(IOptions<WhatsAppWebHookSettings> options)
        {
            _settings = options.Value;
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
    }
}
