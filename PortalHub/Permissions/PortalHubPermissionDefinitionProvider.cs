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

        var produtoPermission = myGroup.AddPermission(PortalHubPermissions.Produtos.Default, L("Permission:Produtos"));
        produtoPermission.AddChild(PortalHubPermissions.Produtos.Create, L("Permission:Create"));
        produtoPermission.AddChild(PortalHubPermissions.Produtos.Edit, L("Permission:Edit"));
        produtoPermission.AddChild(PortalHubPermissions.Produtos.Delete, L("Permission:Delete"));

        var categoriaProdutoPermission = myGroup.AddPermission(PortalHubPermissions.CategoriaProdutos.Default, L("Permission:CategoriaProdutos"));
        categoriaProdutoPermission.AddChild(PortalHubPermissions.CategoriaProdutos.Create, L("Permission:Create"));
        categoriaProdutoPermission.AddChild(PortalHubPermissions.CategoriaProdutos.Edit, L("Permission:Edit"));
        categoriaProdutoPermission.AddChild(PortalHubPermissions.CategoriaProdutos.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PortalHubResource>(name);
    }
}