using PortalHub.Produtos;

using System;
using System.Collections.Generic;

namespace PortalHub.CategoriaProdutos
{
    public abstract class CategoriaProdutoWithNavigationPropertiesBase
    {
        public CategoriaProduto CategoriaProduto { get; set; } = null!;

        

        public List<Produto> Produtos { get; set; } = null!;
        
    }
}