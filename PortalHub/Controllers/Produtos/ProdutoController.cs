using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using PortalHub.Produtos;

namespace PortalHub.Produtos
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Produto")]
    [Route("api/app/produtos")]

    public abstract class ProdutoControllerBase : AbpController
    {
        protected IProdutosAppService _produtosAppService;

        public ProdutoControllerBase(IProdutosAppService produtosAppService)
        {
            _produtosAppService = produtosAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ProdutoDto>> GetListAsync(GetProdutosInput input)
        {
            return _produtosAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ProdutoDto> GetAsync(Guid id)
        {
            return _produtosAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ProdutoDto> CreateAsync(ProdutoCreateDto input)
        {
            return _produtosAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ProdutoDto> UpdateAsync(Guid id, ProdutoUpdateDto input)
        {
            return _produtosAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _produtosAppService.DeleteAsync(id);
        }
        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<Guid> produtoIds)
        {
            return _produtosAppService.DeleteByIdsAsync(produtoIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetProdutosInput input)
        {
            return _produtosAppService.DeleteAllAsync(input);
        }
    }
}