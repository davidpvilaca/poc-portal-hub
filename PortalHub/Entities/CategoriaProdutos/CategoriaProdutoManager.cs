using PortalHub.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace PortalHub.CategoriaProdutos
{
    public abstract class CategoriaProdutoManagerBase : DomainService
    {
        protected ICategoriaProdutoRepository _categoriaProdutoRepository;
        protected IRepository<Produto, Guid> _produtoRepository;

        public CategoriaProdutoManagerBase(ICategoriaProdutoRepository categoriaProdutoRepository,
        IRepository<Produto, Guid> produtoRepository)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
            _produtoRepository = produtoRepository;
        }

        public virtual async Task<CategoriaProduto> CreateAsync(
        List<Guid> produtoIds,
        string nome, string? descricao = null)
        {
            Check.NotNullOrWhiteSpace(nome, nameof(nome));

            var categoriaProduto = new CategoriaProduto(
             GuidGenerator.Create(),
             nome, descricao
             );

            await SetProdutosAsync(categoriaProduto, produtoIds);

            return await _categoriaProdutoRepository.InsertAsync(categoriaProduto);
        }

        public virtual async Task<CategoriaProduto> UpdateAsync(
            Guid id,
            List<Guid> produtoIds,
        string nome, string? descricao = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(nome, nameof(nome));

            var queryable = await _categoriaProdutoRepository.WithDetailsAsync(x => x.Produtos);
            var query = queryable.Where(x => x.Id == id);

            var categoriaProduto = await AsyncExecuter.FirstOrDefaultAsync(query);

            categoriaProduto.Nome = nome;
            categoriaProduto.Descricao = descricao;

            await SetProdutosAsync(categoriaProduto, produtoIds);

            categoriaProduto.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _categoriaProdutoRepository.UpdateAsync(categoriaProduto);
        }

        private async Task SetProdutosAsync(CategoriaProduto categoriaProduto, List<Guid> produtoIds)
        {
            if (produtoIds == null || !produtoIds.Any())
            {
                categoriaProduto.RemoveAllProdutos();
                return;
            }

            var query = (await _produtoRepository.GetQueryableAsync())
                .Where(x => produtoIds.Contains(x.Id))
                .Select(x => x.Id);

            var produtoIdsInDb = await AsyncExecuter.ToListAsync(query);
            if (!produtoIdsInDb.Any())
            {
                return;
            }

            categoriaProduto.RemoveAllProdutosExceptGivenIds(produtoIdsInDb);

            foreach (var produtoId in produtoIdsInDb)
            {
                categoriaProduto.AddProduto(produtoId);
            }
        }

    }
}