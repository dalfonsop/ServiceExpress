using ServiceExpress.Domain;
using ServiceExpress.Infrastructure.Interfaces;
using ServiceExpress.Infrastructure.Persistence;

namespace ServiceExpress.Infrastructure.Repository
{
    public class RegistroConversacionRepository : IRegistroConversacionRepository
    {
        private readonly IGenericDapperRepository<ResgistroConversacion> _genericDapperRepository;

        public RegistroConversacionRepository(IGenericDapperRepository<ResgistroConversacion> genericDapperRepository)
        {
            _genericDapperRepository = genericDapperRepository;
        }

        public async Task<IEnumerable<ResgistroConversacion>> GetAllAsync()
        {
            var response = _genericDapperRepository.GetAllAsync();
            return await response;
        }
    }
}
