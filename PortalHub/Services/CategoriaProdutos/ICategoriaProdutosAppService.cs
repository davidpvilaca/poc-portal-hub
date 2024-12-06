using PortalHub.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PortalHub.CategoriaProdutos
{
    public partial interface ICategoriaProdutosAppService : IApplicationService
    {

        Task<PagedResultDto<CategoriaProdutoWithNavigationPropertiesDto>> GetListAsync(GetCategoriaProdutosInput input);

        Task<CategoriaProdutoWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<CategoriaProdutoDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetProdutoLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<CategoriaProdutoDto> CreateAsync(CategoriaProdutoCreateDto input);

        Task<CategoriaProdutoDto> UpdateAsync(Guid id, CategoriaProdutoUpdateDto input); Task DeleteByIdsAsync(List<Guid> categoriaprodutoIds);

        Task DeleteAllAsync(GetCategoriaProdutosInput input);
    }
}