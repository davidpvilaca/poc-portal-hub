using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using PortalHub.Data;

namespace PortalHub.Produtos
{
    public class EfCoreProdutoRepository : EfCoreProdutoRepositoryBase, IProdutoRepository
    {
        public EfCoreProdutoRepository(IDbContextProvider<PortalHubDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}