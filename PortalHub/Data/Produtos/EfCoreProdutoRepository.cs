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

namespace PortalHub.Produtos
{
    public abstract class EfCoreProdutoRepositoryBase : EfCoreRepository<PortalHubDbContext, Produto, Guid>
    {
        public EfCoreProdutoRepositoryBase(IDbContextProvider<PortalHubDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? nome = null,
            string? descricao = null,
            string? cicloDeVida = null,
            DateOnly? dataPublicacaoMin = null,
            DateOnly? dataPublicacaoMax = null,
            string? plataforma = null,
            string? tecnologias = null,
            string? status = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, nome, descricao, cicloDeVida, dataPublicacaoMin, dataPublicacaoMax, plataforma, tecnologias, status);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Produto>> GetListAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            string? cicloDeVida = null,
            DateOnly? dataPublicacaoMin = null,
            DateOnly? dataPublicacaoMax = null,
            string? plataforma = null,
            string? tecnologias = null,
            string? status = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, nome, descricao, cicloDeVida, dataPublicacaoMin, dataPublicacaoMax, plataforma, tecnologias, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ProdutoConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            string? cicloDeVida = null,
            DateOnly? dataPublicacaoMin = null,
            DateOnly? dataPublicacaoMax = null,
            string? plataforma = null,
            string? tecnologias = null,
            string? status = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, nome, descricao, cicloDeVida, dataPublicacaoMin, dataPublicacaoMax, plataforma, tecnologias, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Produto> ApplyFilter(
            IQueryable<Produto> query,
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            string? cicloDeVida = null,
            DateOnly? dataPublicacaoMin = null,
            DateOnly? dataPublicacaoMax = null,
            string? plataforma = null,
            string? tecnologias = null,
            string? status = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Nome!.Contains(filterText!) || e.Descricao!.Contains(filterText!) || e.CicloDeVida!.Contains(filterText!) || e.Plataforma!.Contains(filterText!) || e.Tecnologias!.Contains(filterText!) || e.Status!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(nome), e => e.Nome.Contains(nome))
                    .WhereIf(!string.IsNullOrWhiteSpace(descricao), e => e.Descricao.Contains(descricao))
                    .WhereIf(!string.IsNullOrWhiteSpace(cicloDeVida), e => e.CicloDeVida.Contains(cicloDeVida))
                    .WhereIf(dataPublicacaoMin.HasValue, e => e.DataPublicacao >= dataPublicacaoMin!.Value)
                    .WhereIf(dataPublicacaoMax.HasValue, e => e.DataPublicacao <= dataPublicacaoMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(plataforma), e => e.Plataforma.Contains(plataforma))
                    .WhereIf(!string.IsNullOrWhiteSpace(tecnologias), e => e.Tecnologias.Contains(tecnologias))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status));
        }
    }
}