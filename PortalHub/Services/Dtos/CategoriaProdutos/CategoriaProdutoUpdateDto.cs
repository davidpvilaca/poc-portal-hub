using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace PortalHub.CategoriaProdutos
{
    public abstract class CategoriaProdutoUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public List<Guid> ProdutoIds { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}