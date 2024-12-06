using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PortalHub.Produtos
{
    public partial interface IProdutosAppService : IApplicationService
    {

        Task<PagedResultDto<ProdutoDto>> GetListAsync(GetProdutosInput input);

        Task<ProdutoDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ProdutoDto> CreateAsync(ProdutoCreateDto input);

        Task<ProdutoDto> UpdateAsync(Guid id, ProdutoUpdateDto input); Task DeleteByIdsAsync(List<Guid> produtoIds);

        Task DeleteAllAsync(GetProdutosInput input);
    }
}