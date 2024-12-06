using PortalHub.Shared;
using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using PortalHub.CategoriaProdutos;

namespace PortalHub.CategoriaProdutos
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CategoriaProduto")]
    [Route("api/app/categoria-produtos")]

    public abstract class CategoriaProdutoControllerBase : AbpController
    {
        protected ICategoriaProdutosAppService _categoriaProdutosAppService;

        public CategoriaProdutoControllerBase(ICategoriaProdutosAppService categoriaProdutosAppService)
        {
            _categoriaProdutosAppService = categoriaProdutosAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CategoriaProdutoWithNavigationPropertiesDto>> GetListAsync(GetCategoriaProdutosInput input)
        {
            return _categoriaProdutosAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<CategoriaProdutoWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _categoriaProdutosAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CategoriaProdutoDto> GetAsync(Guid id)
        {
            return _categoriaProdutosAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("produto-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetProdutoLookupAsync(LookupRequestDto input)
        {
            return _categoriaProdutosAppService.GetProdutoLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<CategoriaProdutoDto> CreateAsync(CategoriaProdutoCreateDto input)
        {
            return _categoriaProdutosAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CategoriaProdutoDto> UpdateAsync(Guid id, CategoriaProdutoUpdateDto input)
        {
            return _categoriaProdutosAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _categoriaProdutosAppService.DeleteAsync(id);
        }
        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<Guid> categoriaprodutoIds)
        {
            return _categoriaProdutosAppService.DeleteByIdsAsync(categoriaprodutoIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetCategoriaProdutosInput input)
        {
            return _categoriaProdutosAppService.DeleteAllAsync(input);
        }
    }
}