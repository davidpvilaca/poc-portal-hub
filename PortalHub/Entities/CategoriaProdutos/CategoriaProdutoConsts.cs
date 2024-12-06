namespace PortalHub.CategoriaProdutos
{
    public static class CategoriaProdutoConsts
    {
        private const string DefaultSorting = "{0}Nome asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CategoriaProduto." : string.Empty);
        }

    }
}