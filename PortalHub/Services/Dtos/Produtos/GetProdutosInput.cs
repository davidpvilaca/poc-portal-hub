using Volo.Abp.Application.Dtos;
using System;

namespace PortalHub.Produtos
{
    public abstract class GetProdutosInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? CicloDeVida { get; set; }
        public DateOnly? DataPublicacaoMin { get; set; }
        public DateOnly? DataPublicacaoMax { get; set; }
        public string? Plataforma { get; set; }
        public string? Tecnologias { get; set; }
        public string? Status { get; set; }

        public GetProdutosInputBase()
        {

        }
    }
}