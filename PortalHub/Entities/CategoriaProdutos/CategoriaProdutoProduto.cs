using System;
using Volo.Abp.Domain.Entities;

namespace PortalHub.CategoriaProdutos
{
    public class CategoriaProdutoProduto : Entity
    {

        public Guid CategoriaProdutoId { get; protected set; }

        public Guid ProdutoId { get; protected set; }

        private CategoriaProdutoProduto()
        {

        }

        public CategoriaProdutoProduto(Guid categoriaProdutoId, Guid produtoId)
        {
            CategoriaProdutoId = categoriaProdutoId;
            ProdutoId = produtoId;
        }

        public override object[] GetKeys()
        {
            return new object[]
                {
                    CategoriaProdutoId,
                    ProdutoId
                };
        }
    }
}