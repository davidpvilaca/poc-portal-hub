using PortalHub.Produtos;
using PortalHub.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using PortalHub.Data;

namespace PortalHub.CategoriaProdutos
{
    public abstract class EfCoreCategoriaProdutoRepositoryBase : EfCoreRepository<PortalHubDbContext, CategoriaProduto, Guid>
    {
        public EfCoreCategoriaProdutoRepositoryBase(IDbContextProvider<PortalHubDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? nome = null,
            string? descricao = null,
            Guid? produtoId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();

            query = ApplyFilter(query, filterText, nome, descricao, produtoId);

            var ids = query.Select(x => x.CategoriaProduto.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<CategoriaProdutoWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id).Include(x => x.Produtos)
                .Select(categoriaProduto => new CategoriaProdutoWithNavigationProperties
                {
                    CategoriaProduto = categoriaProduto,
                    Produtos = (from categoriaProdutoProdutos in categoriaProduto.Produtos
                                join _produto in dbContext.Set<Produto>() on categoriaProdutoProdutos.ProdutoId equals _produto.Id
                                select _produto).ToList()
                }).FirstOrDefault();
        }

        public virtual async Task<List<CategoriaProdutoWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            Guid? produtoId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, nome, descricao, produtoId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CategoriaProdutoConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<CategoriaProdutoWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from categoriaProduto in (await GetDbSetAsync())

                   select new CategoriaProdutoWithNavigationProperties
                   {
                       CategoriaProduto = categoriaProduto,
                       Produtos = new List<Produto>()
                   };
        }

        protected virtual IQueryable<CategoriaProdutoWithNavigationProperties> ApplyFilter(
            IQueryable<CategoriaProdutoWithNavigationProperties> query,
            string? filterText,
            string? nome = null,
            string? descricao = null,
            Guid? produtoId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CategoriaProduto.Nome!.Contains(filterText!) || e.CategoriaProduto.Descricao!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(nome), e => e.CategoriaProduto.Nome.Contains(nome))
                    .WhereIf(!string.IsNullOrWhiteSpace(descricao), e => e.CategoriaProduto.Descricao.Contains(descricao))
                    .WhereIf(produtoId != null && produtoId != Guid.Empty, e => e.CategoriaProduto.Produtos.Any(x => x.ProdutoId == produtoId));
        }

        public virtual async Task<List<CategoriaProduto>> GetListAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, nome, descricao);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CategoriaProdutoConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            Guid? produtoId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, nome, descricao, produtoId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CategoriaProduto> ApplyFilter(
            IQueryable<CategoriaProduto> query,
            string? filterText = null,
            string? nome = null,
            string? descricao = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Nome!.Contains(filterText!) || e.Descricao!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(nome), e => e.Nome.Contains(nome))
                    .WhereIf(!string.IsNullOrWhiteSpace(descricao), e => e.Descricao.Contains(descricao));
        }
    }
}