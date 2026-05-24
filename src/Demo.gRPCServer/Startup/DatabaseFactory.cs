using Microsoft.EntityFrameworkCore;
using Demo.Infrastructure.SqlStorage.Data;

namespace Demo.gRPCServer.Startup;

public static class DatabaseFactory
{
    public static void AddInMemoryDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("DemoDb"));
    }
}
