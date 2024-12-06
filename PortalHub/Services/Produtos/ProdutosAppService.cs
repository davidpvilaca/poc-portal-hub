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
using PortalHub.Produtos;

namespace PortalHub.Produtos
{
    [RemoteService(IsEnabled = false)]
    [Authorize(PortalHubPermissions.Produtos.Default)]
    public abstract class ProdutosAppServiceBase : ApplicationService
    {

        protected IProdutoRepository _produtoRepository;
        protected ProdutoManager _produtoManager;

        public ProdutosAppServiceBase(IProdutoRepository produtoRepository, ProdutoManager produtoManager)
        {

            _produtoRepository = produtoRepository;
            _produtoManager = produtoManager;

        }

        public virtual async Task<PagedResultDto<ProdutoDto>> GetListAsync(GetProdutosInput input)
        {
            var totalCount = await _produtoRepository.GetCountAsync(input.FilterText, input.Nome, input.Descricao, input.CicloDeVida, input.DataPublicacaoMin, input.DataPublicacaoMax, input.Plataforma, input.Tecnologias, input.Status);
            var items = await _produtoRepository.GetListAsync(input.FilterText, input.Nome, input.Descricao, input.CicloDeVida, input.DataPublicacaoMin, input.DataPublicacaoMax, input.Plataforma, input.Tecnologias, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ProdutoDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Produto>, List<ProdutoDto>>(items)
            };
        }

        public virtual async Task<ProdutoDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Produto, ProdutoDto>(await _produtoRepository.GetAsync(id));
        }

        [Authorize(PortalHubPermissions.Produtos.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _produtoRepository.DeleteAsync(id);
        }

        [Authorize(PortalHubPermissions.Produtos.Create)]
        public virtual async Task<ProdutoDto> CreateAsync(ProdutoCreateDto input)
        {

            var produto = await _produtoManager.CreateAsync(
            input.Nome, input.CicloDeVida, input.DataPublicacao, input.Descricao, input.LinkDocumentacao, input.Plataforma, input.Tecnologias, input.Status
            );

            return ObjectMapper.Map<Produto, ProdutoDto>(produto);
        }

        [Authorize(PortalHubPermissions.Produtos.Edit)]
        public virtual async Task<ProdutoDto> UpdateAsync(Guid id, ProdutoUpdateDto input)
        {

            var produto = await _produtoManager.UpdateAsync(
            id,
            input.Nome, input.CicloDeVida, input.DataPublicacao, input.Descricao, input.LinkDocumentacao, input.Plataforma, input.Tecnologias, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Produto, ProdutoDto>(produto);
        }
        [Authorize(PortalHubPermissions.Produtos.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> produtoIds)
        {
            await _produtoRepository.DeleteManyAsync(produtoIds);
        }

        [Authorize(PortalHubPermissions.Produtos.Delete)]
        public virtual async Task DeleteAllAsync(GetProdutosInput input)
        {
            await _produtoRepository.DeleteAllAsync(input.FilterText, input.Nome, input.Descricao, input.CicloDeVida, input.DataPublicacaoMin, input.DataPublicacaoMax, input.Plataforma, input.Tecnologias, input.Status);
        }
    }
}