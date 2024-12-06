using PortalHub.Produtos;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace PortalHub.CategoriaProdutos
{
    public abstract class CategoriaProdutoWithNavigationPropertiesDtoBase
    {
        public CategoriaProdutoDto CategoriaProduto { get; set; } = null!;

        public List<ProdutoDto> Produtos { get; set; } = new List<ProdutoDto>();

    }
}