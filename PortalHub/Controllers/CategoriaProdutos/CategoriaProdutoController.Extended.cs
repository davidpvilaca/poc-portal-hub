using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using PortalHub.CategoriaProdutos;

namespace PortalHub.CategoriaProdutos
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CategoriaProduto")]
    [Route("api/app/categoria-produtos")]

    public class CategoriaProdutoController : CategoriaProdutoControllerBase, ICategoriaProdutosAppService
    {
        public CategoriaProdutoController(ICategoriaProdutosAppService categoriaProdutosAppService) : base(categoriaProdutosAppService)
        {
        }
    }
}