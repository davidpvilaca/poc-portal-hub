using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace PortalHub.CategoriaProdutos
{
    public abstract class CategoriaProdutoDtoBase : AuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}