namespace PortalHub.Permissions;

public static class PortalHubPermissions
{
    public const string GroupName = "PortalHub";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Produtos
    {
        public const string Default = GroupName + ".Produtos";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class CategoriaProdutos
    {
        public const string Default = GroupName + ".CategoriaProdutos";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}