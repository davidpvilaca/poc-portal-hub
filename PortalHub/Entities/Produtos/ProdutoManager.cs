using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace PortalHub.Produtos
{
    public abstract class ProdutoManagerBase : DomainService
    {
        protected IProdutoRepository _produtoRepository;

        public ProdutoManagerBase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public virtual async Task<Produto> CreateAsync(
        string nome, string cicloDeVida, DateOnly dataPublicacao, string? descricao = null, string? linkDocumentacao = null, string? plataforma = null, string? tecnologias = null, string? status = null)
        {
            Check.NotNullOrWhiteSpace(nome, nameof(nome));
            Check.NotNullOrWhiteSpace(cicloDeVida, nameof(cicloDeVida));

            var produto = new Produto(
             GuidGenerator.Create(),
             nome, cicloDeVida, dataPublicacao, descricao, linkDocumentacao, plataforma, tecnologias, status
             );

            return await _produtoRepository.InsertAsync(produto);
        }

        public virtual async Task<Produto> UpdateAsync(
            Guid id,
            string nome, string cicloDeVida, DateOnly dataPublicacao, string? descricao = null, string? linkDocumentacao = null, string? plataforma = null, string? tecnologias = null, string? status = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(nome, nameof(nome));
            Check.NotNullOrWhiteSpace(cicloDeVida, nameof(cicloDeVida));

            var produto = await _produtoRepository.GetAsync(id);

            produto.Nome = nome;
            produto.CicloDeVida = cicloDeVida;
            produto.DataPublicacao = dataPublicacao;
            produto.Descricao = descricao;
            produto.LinkDocumentacao = linkDocumentacao;
            produto.Plataforma = plataforma;
            produto.Tecnologias = tecnologias;
            produto.Status = status;

            produto.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _produtoRepository.UpdateAsync(produto);
        }

    }
}