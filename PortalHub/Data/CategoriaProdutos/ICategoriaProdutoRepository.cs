using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PortalHub.CategoriaProdutos
{
    public partial interface ICategoriaProdutoRepository : IRepository<CategoriaProduto, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            Guid? produtoId = null,
            CancellationToken cancellationToken = default);
        Task<CategoriaProdutoWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<List<CategoriaProdutoWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            Guid? produtoId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<CategoriaProduto>> GetListAsync(
                    string? filterText = null,
                    string? nome = null,
                    string? descricao = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            Guid? produtoId = null,
            CancellationToken cancellationToken = default);
    }
}