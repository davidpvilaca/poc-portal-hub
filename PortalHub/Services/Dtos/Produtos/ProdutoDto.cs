using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace PortalHub.Produtos
{
    public abstract class ProdutoDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public string CicloDeVida { get; set; } = null!;
        public DateOnly DataPublicacao { get; set; }
        public string? LinkDocumentacao { get; set; }
        public string? Plataforma { get; set; }
        public string? Tecnologias { get; set; }
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}