using ServiceExpress.Application.Common;

namespace ServiceExpress.Application.Interfaces
{
    public interface IWhatsAppWebHookService
    {
        Result<int> VerificateRequest(string mode,int challenge,string veryfyToken);  
    }
}
