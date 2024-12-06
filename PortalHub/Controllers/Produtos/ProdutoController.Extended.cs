using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using PortalHub.Produtos;

namespace PortalHub.Produtos
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Produto")]
    [Route("api/app/produtos")]

    public class ProdutoController : ProdutoControllerBase, IProdutosAppService
    {
        public ProdutoController(IProdutosAppService produtosAppService) : base(produtosAppService)
        {
        }
    }
}