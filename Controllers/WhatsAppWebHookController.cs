using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceExpress.Application.Common;
using ServiceExpress.Application.Configurations;
using ServiceExpress.Application.Interfaces;
using ServiceExpress.Controllers.Extensions;
using ServiceExpress.Domain;

namespace ServiceExpress.Controllers
{
    [ApiController]
    public class WhatsAppWebHookController : ControllerBase
    {
        private readonly IWhatsAppWebHookService _whatsAppWebHookService;
        private readonly WhatsAppWebHookSettings _settings;


        public WhatsAppWebHookController(IWhatsAppWebHookService whatsAppWebHookService, IOptions<WhatsAppWebHookSettings> options)
        {
            _whatsAppWebHookService = whatsAppWebHookService;
            _settings = options.Value;
        }

        /* [HttpGet("webhook")]
         public IResult VerificationRequest([FromQuery(Name = "hub.mode")] string mode, [FromQuery(Name = "hub.challenge")] int challenge, [FromQuery(Name = "hub.hub.verify_token")] string veryfyToken)
         {
             //var response = _whatsAppWebHookService.VerificateRequest(mode, challenge, veryfyToken);
             //return response.ToActionResult(this);

             if (mode == "subscribe" && veryfyToken == _settings.VerifyToken)
             {
                 return Results.Text(challenge.ToString(), "text/plain");
             }

             return Results.StatusCode(403);

         }*/

        [HttpPost("webhook")]
        public async Task<IResult> RecieveData(WebhookMessageRequest request)
        {
            using var reader = new StreamReader(Request.Body);
            var body = await reader.ReadToEndAsync();
            _whatsAppWebHookService.RecieveData(request); 

            return Results.StatusCode(200);

        }
    }
}
