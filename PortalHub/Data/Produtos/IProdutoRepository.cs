using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PortalHub.Produtos
{
    public partial interface IProdutoRepository : IRepository<Produto, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            string? cicloDeVida = null,
            DateOnly? dataPublicacaoMin = null,
            DateOnly? dataPublicacaoMax = null,
            string? plataforma = null,
            string? tecnologias = null,
            string? status = null,
            CancellationToken cancellationToken = default);
        Task<List<Produto>> GetListAsync(
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
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? nome = null,
            string? descricao = null,
            string? cicloDeVida = null,
            DateOnly? dataPublicacaoMin = null,
            DateOnly? dataPublicacaoMax = null,
            string? plataforma = null,
            string? tecnologias = null,
            string? status = null,
            CancellationToken cancellationToken = default);
    }
}