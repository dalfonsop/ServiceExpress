using Npgsql;
using System.Data;

namespace ServiceExpress.Infrastructure.Persistence;

public class DapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_configuration.GetConnectionString("ServiExpressDB"));
}
