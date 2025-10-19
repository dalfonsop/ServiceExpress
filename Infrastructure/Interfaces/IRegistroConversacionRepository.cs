using ServiceExpress.Domain;

namespace ServiceExpress.Infrastructure.Interfaces
{
    public interface IRegistroConversacionRepository
    {
        Task<IEnumerable<ResgistroConversacion>> GetAllAsync();
    }
}
