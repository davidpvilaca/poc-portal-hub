using Volo.Abp.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PortalHub.Data;

public class PortalHubDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public PortalHubDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        
        /* We intentionally resolving the PortalHubDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PortalHubDbContext>()
            .Database
            .MigrateAsync();

    }
}
