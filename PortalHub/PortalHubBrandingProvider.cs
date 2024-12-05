using Microsoft.Extensions.Localization;
using PortalHub.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace PortalHub;

[Dependency(ReplaceServices = true)]
public class PortalHubBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<PortalHubResource> _localizer;

    public PortalHubBrandingProvider(IStringLocalizer<PortalHubResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}