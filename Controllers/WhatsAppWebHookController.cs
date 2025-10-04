using Microsoft.AspNetCore.Mvc;
using ServiceExpress.Application.Common;
using ServiceExpress.Application.Interfaces;
using ServiceExpress.Controllers.Extensions;

namespace ServiceExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhatsAppWebHookController : ControllerBase
    {
        private readonly IWhatsAppWebHookService _whatsAppWebHookService;

        public WhatsAppWebHookController(IWhatsAppWebHookService whatsAppWebHookService)
        {
                _whatsAppWebHookService = whatsAppWebHookService;
        }

        [HttpGet("webhook")]
        public ActionResult<int> VerificationRequest([FromQuery(Name = "hub.mode")] string mode, [FromQuery(Name = "hub.challenge")] int challenge, [FromQuery(Name = "hub.hub.verify_token")] string veryfyToken)
        {
            var response = _whatsAppWebHookService.VerificateRequest(mode, challenge, veryfyToken);
            return response.ToActionResult(this);

        }
    }
}
