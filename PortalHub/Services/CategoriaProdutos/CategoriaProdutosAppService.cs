using PortalHub.Shared;
using PortalHub.Produtos;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using PortalHub.Permissions;
using PortalHub.CategoriaProdutos;

namespace PortalHub.CategoriaProdutos
{
    [RemoteService(IsEnabled = false)]
    [Authorize(PortalHubPermissions.CategoriaProdutos.Default)]
    public abstract class CategoriaProdutosAppServiceBase : ApplicationService
    {

        protected ICategoriaProdutoRepository _categoriaProdutoRepository;
        protected CategoriaProdutoManager _categoriaProdutoManager;

        protected IRepository<PortalHub.Produtos.Produto, Guid> _produtoRepository;

        public CategoriaProdutosAppServiceBase(ICategoriaProdutoRepository categoriaProdutoRepository, CategoriaProdutoManager categoriaProdutoManager, IRepository<PortalHub.Produtos.Produto, Guid> produtoRepository)
        {

            _categoriaProdutoRepository = categoriaProdutoRepository;
            _categoriaProdutoManager = categoriaProdutoManager; _produtoRepository = produtoRepository;

        }

        public virtual async Task<PagedResultDto<CategoriaProdutoWithNavigationPropertiesDto>> GetListAsync(GetCategoriaProdutosInput input)
        {
            var totalCount = await _categoriaProdutoRepository.GetCountAsync(input.FilterText, input.Nome, input.Descricao, input.ProdutoId);
            var items = await _categoriaProdutoRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Nome, input.Descricao, input.ProdutoId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CategoriaProdutoWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CategoriaProdutoWithNavigationProperties>, List<CategoriaProdutoWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<CategoriaProdutoWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<CategoriaProdutoWithNavigationProperties, CategoriaProdutoWithNavigationPropertiesDto>
                (await _categoriaProdutoRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<CategoriaProdutoDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CategoriaProduto, CategoriaProdutoDto>(await _categoriaProdutoRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetProdutoLookupAsync(LookupRequestDto input)
        {
            var query = (await _produtoRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Nome != null &&
                         x.Nome.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<PortalHub.Produtos.Produto>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PortalHub.Produtos.Produto>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(PortalHubPermissions.CategoriaProdutos.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _categoriaProdutoRepository.DeleteAsync(id);
        }

        [Authorize(PortalHubPermissions.CategoriaProdutos.Create)]
        public virtual async Task<CategoriaProdutoDto> CreateAsync(CategoriaProdutoCreateDto input)
        {

            var categoriaProduto = await _categoriaProdutoManager.CreateAsync(
            input.ProdutoIds, input.Nome, input.Descricao
            );

            return ObjectMapper.Map<CategoriaProduto, CategoriaProdutoDto>(categoriaProduto);
        }

        [Authorize(PortalHubPermissions.CategoriaProdutos.Edit)]
        public virtual async Task<CategoriaProdutoDto> UpdateAsync(Guid id, CategoriaProdutoUpdateDto input)
        {

            var categoriaProduto = await _categoriaProdutoManager.UpdateAsync(
            id,
            input.ProdutoIds, input.Nome, input.Descricao, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<CategoriaProduto, CategoriaProdutoDto>(categoriaProduto);
        }
        [Authorize(PortalHubPermissions.CategoriaProdutos.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> categoriaprodutoIds)
        {
            await _categoriaProdutoRepository.DeleteManyAsync(categoriaprodutoIds);
        }

        [Authorize(PortalHubPermissions.CategoriaProdutos.Delete)]
        public virtual async Task DeleteAllAsync(GetCategoriaProdutosInput input)
        {
            await _categoriaProdutoRepository.DeleteAllAsync(input.FilterText, input.Nome, input.Descricao, input.ProdutoId);
        }
    }
}