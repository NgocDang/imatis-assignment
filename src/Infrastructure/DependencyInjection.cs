using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AssignmentDbContext>(options => options.UseSqlite(configuration.GetConnectionString("imatis"), b => b.MigrationsAssembly("Assignment")));

        using var serviceProvider = services.BuildServiceProvider();
        var context = serviceProvider.GetRequiredService<AssignmentDbContext>();
        context.Database.Migrate();

        return services;
    }
}
