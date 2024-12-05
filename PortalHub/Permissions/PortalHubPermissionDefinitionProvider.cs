using PortalHub.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PortalHub.Permissions;

public class PortalHubPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PortalHubPermissions.GroupName);


        //Define your own permissions here. Example:
        //myGroup.AddPermission(PortalHubPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PortalHubResource>(name);
    }
}
