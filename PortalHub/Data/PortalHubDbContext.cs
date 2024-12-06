using PortalHub.CategoriaProdutos;
using PortalHub.Produtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace PortalHub.Data;

public class PortalHubDbContext : AbpDbContext<PortalHubDbContext>
{
    public DbSet<CategoriaProduto> CategoriaProdutos { get; set; } = null!;
    public DbSet<Produto> Produtos { get; set; } = null!;

    public const string DbTablePrefix = "App";
    public const string DbSchema = null;

    public PortalHubDbContext(DbContextOptions<PortalHubDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureFeatureManagement();
        builder.ConfigurePermissionManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddictPro();

        /* Configure your own entities here */
        if (builder.IsHostDatabase())
        {
            builder.Entity<Produto>(b =>
            {
                b.ToTable(DbTablePrefix + "Produtos", DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Nome).HasColumnName(nameof(Produto.Nome)).IsRequired();
                b.Property(x => x.Descricao).HasColumnName(nameof(Produto.Descricao));
                b.Property(x => x.CicloDeVida).HasColumnName(nameof(Produto.CicloDeVida)).IsRequired();
                b.Property(x => x.DataPublicacao).HasColumnName(nameof(Produto.DataPublicacao));
                b.Property(x => x.LinkDocumentacao).HasColumnName(nameof(Produto.LinkDocumentacao));
                b.Property(x => x.Plataforma).HasColumnName(nameof(Produto.Plataforma));
                b.Property(x => x.Tecnologias).HasColumnName(nameof(Produto.Tecnologias));
                b.Property(x => x.Status).HasColumnName(nameof(Produto.Status));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<CategoriaProduto>(b =>
            {
                b.ToTable(DbTablePrefix + "CategoriaProdutos", DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Nome).HasColumnName(nameof(CategoriaProduto.Nome)).IsRequired();
                b.Property(x => x.Descricao).HasColumnName(nameof(CategoriaProduto.Descricao));
                b.HasMany(x => x.Produtos).WithOne().HasForeignKey(x => x.CategoriaProdutoId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<CategoriaProdutoProduto>(b =>
        {
            b.ToTable(DbTablePrefix + "CategoriaProdutoProduto", DbSchema);
            b.ConfigureByConvention();

            b.HasKey(
                x => new { x.CategoriaProdutoId, x.ProdutoId }
            );

            b.HasOne<CategoriaProduto>().WithMany(x => x.Produtos).HasForeignKey(x => x.CategoriaProdutoId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            b.HasOne<Produto>().WithMany().HasForeignKey(x => x.ProdutoId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            b.HasIndex(
                    x => new { x.CategoriaProdutoId, x.ProdutoId }
            );
        });
        }
    }
}