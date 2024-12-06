using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace PortalHub.Produtos
{
    public abstract class ProdutoUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        [Required]
        public string CicloDeVida { get; set; } = null!;
        public DateOnly DataPublicacao { get; set; }
        public string? LinkDocumentacao { get; set; }
        public string? Plataforma { get; set; }
        public string? Tecnologias { get; set; }
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}