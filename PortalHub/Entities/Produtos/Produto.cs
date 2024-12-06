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
    public abstract class ProdutoBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Nome { get; set; }

        [CanBeNull]
        public virtual string? Descricao { get; set; }

        [NotNull]
        public virtual string CicloDeVida { get; set; }

        public virtual DateOnly DataPublicacao { get; set; }

        [CanBeNull]
        public virtual string? LinkDocumentacao { get; set; }

        [CanBeNull]
        public virtual string? Plataforma { get; set; }

        [CanBeNull]
        public virtual string? Tecnologias { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        protected ProdutoBase()
        {

        }

        public ProdutoBase(Guid id, string nome, string cicloDeVida, DateOnly dataPublicacao, string? descricao = null, string? linkDocumentacao = null, string? plataforma = null, string? tecnologias = null, string? status = null)
        {

            Id = id;
            Check.NotNull(nome, nameof(nome));
            Check.NotNull(cicloDeVida, nameof(cicloDeVida));
            Nome = nome;
            CicloDeVida = cicloDeVida;
            DataPublicacao = dataPublicacao;
            Descricao = descricao;
            LinkDocumentacao = linkDocumentacao;
            Plataforma = plataforma;
            Tecnologias = tecnologias;
            Status = status;
        }

    }
}