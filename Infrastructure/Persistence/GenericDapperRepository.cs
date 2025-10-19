
using Dapper.Contrib.Extensions;

namespace ServiceExpress.Infrastructure.Persistence
{
    public class GenericDapperRepository<T> : IGenericDapperRepository <T> where T : class
    {
        private readonly DapperContext _context;

        public GenericDapperRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(long id)
        {
            using var conn = _context.CreateConnection();
            return await conn.GetAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var conn = _context.CreateConnection();
            return await conn.GetAllAsync<T>();
        }

        public async Task<long> InsertAsync(T entity)
        {
            using var conn = _context.CreateConnection();
            return await conn.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            using var conn = _context.CreateConnection();
            return await conn.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            using var conn = _context.CreateConnection();
            var entity = await conn.GetAsync<T>(id);
            return entity != null && await conn.DeleteAsync(entity);
        }
    }
}
