namespace PortalHub.Produtos
{
    public static class ProdutoConsts
    {
        private const string DefaultSorting = "{0}Nome asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Produto." : string.Empty);
        }

    }
}