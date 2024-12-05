using Volo.Abp.Application.Services;
using PortalHub.Localization;

namespace PortalHub.Services;

/* Inherit your application services from this class. */
public abstract class PortalHubAppService : ApplicationService
{
    protected PortalHubAppService()
    {
        LocalizationResource = typeof(PortalHubResource);
    }
}