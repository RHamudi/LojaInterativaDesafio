using LojaInterativa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaInterativa.Data.Mappings
{
    public class ProdutosMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.idProduto);
            builder.Property(x => x.idProduto)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.descricaoProduto)
                .IsRequired()
                .HasColumnName("descricaoProduto")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.precoProduto)
                .IsRequired()
                .HasColumnName("precoProduto")
                .HasColumnType("DECIMAL")
                .HasPrecision(18, 2);

            builder.HasOne(x => x.Fabricante)
                .WithMany(x => x.Produto)
                .HasForeignKey(x => x.idFabricante)
                .HasConstraintName("FK_PRODUTO_FABRICANTE");

            builder.Property(x => x.Categoria)
                .IsRequired()
                .HasColumnName("categoriaProduto")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);
        }
    }
}