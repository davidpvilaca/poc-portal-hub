using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PortalHub.CategoriaProdutos
{
    public abstract class CategoriaProdutoCreateDtoBase
    {
        [Required]
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public List<Guid> ProdutoIds { get; set; }
    }
}