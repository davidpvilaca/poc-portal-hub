using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace PortalHub.Produtos
{
    public class Produto : ProdutoBase
    {
        //<suite-custom-code-autogenerated>
        protected Produto()
        {

        }

        public Produto(Guid id, string nome, string cicloDeVida, DateOnly dataPublicacao, string? descricao = null, string? linkDocumentacao = null, string? plataforma = null, string? tecnologias = null, string? status = null)
            : base(id, nome, cicloDeVida, dataPublicacao, descricao, linkDocumentacao, plataforma, tecnologias, status)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}