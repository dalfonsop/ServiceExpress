using ServiceExpress.Application.Common;
using ServiceExpress.Domain;

namespace ServiceExpress.Application.Interfaces
{
    public interface IWhatsAppWebHookService
    {
        Result<int> VerificateRequest(string mode,int challenge,string veryfyToken);  
        void RecieveData(WebhookMessageRequest data);
    }
}
