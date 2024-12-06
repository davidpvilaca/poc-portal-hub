using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

using Volo.Abp;

namespace PortalHub.CategoriaProdutos
{
    public abstract class CategoriaProdutoBase : AuditedEntity<Guid>, IHasConcurrencyStamp
    {
        [NotNull]
        public virtual string Nome { get; set; }

        [CanBeNull]
        public virtual string? Descricao { get; set; }

        public ICollection<CategoriaProdutoProduto> Produtos { get; private set; }

        public string ConcurrencyStamp { get; set; }

        protected CategoriaProdutoBase()
        {

        }

        public CategoriaProdutoBase(Guid id, string nome, string? descricao = null)
        {
            ConcurrencyStamp = Guid.NewGuid().ToString("N");
            Id = id;
            Check.NotNull(nome, nameof(nome));
            Nome = nome;
            Descricao = descricao;
            Produtos = new Collection<CategoriaProdutoProduto>();
        }
        public virtual void AddProduto(Guid produtoId)
        {
            Check.NotNull(produtoId, nameof(produtoId));

            if (IsInProdutos(produtoId))
            {
                return;
            }

            Produtos.Add(new CategoriaProdutoProduto(Id, produtoId));
        }

        public virtual void RemoveProduto(Guid produtoId)
        {
            Check.NotNull(produtoId, nameof(produtoId));

            if (!IsInProdutos(produtoId))
            {
                return;
            }

            Produtos.RemoveAll(x => x.ProdutoId == produtoId);
        }

        public virtual void RemoveAllProdutosExceptGivenIds(List<Guid> produtoIds)
        {
            Check.NotNullOrEmpty(produtoIds, nameof(produtoIds));

            Produtos.RemoveAll(x => !produtoIds.Contains(x.ProdutoId));
        }

        public virtual void RemoveAllProdutos()
        {
            Produtos.RemoveAll(x => x.CategoriaProdutoId == Id);
        }

        private bool IsInProdutos(Guid produtoId)
        {
            return Produtos.Any(x => x.ProdutoId == produtoId);
        }
    }
}