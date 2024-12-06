using Volo.Abp.Application.Dtos;
using System;

namespace PortalHub.CategoriaProdutos
{
    public abstract class GetCategoriaProdutosInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public Guid? ProdutoId { get; set; }

        public GetCategoriaProdutosInputBase()
        {

        }
    }
}