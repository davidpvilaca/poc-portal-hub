using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PortalHub.Produtos
{
    public abstract class ProdutoCreateDtoBase
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
    }
}