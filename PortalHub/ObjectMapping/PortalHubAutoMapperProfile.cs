using PortalHub.CategoriaProdutos;
using System;
using PortalHub.Shared;
using Volo.Abp.AutoMapper;
using PortalHub.Produtos;
using AutoMapper;

namespace PortalHub.ObjectMapping;

public class PortalHubAutoMapperProfile : Profile
{
    public PortalHubAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */

        CreateMap<Produto, ProdutoDto>();

        CreateMap<CategoriaProduto, CategoriaProdutoDto>();
        CreateMap<CategoriaProdutoWithNavigationProperties, CategoriaProdutoWithNavigationPropertiesDto>();
        CreateMap<Produto, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Nome));
    }
}