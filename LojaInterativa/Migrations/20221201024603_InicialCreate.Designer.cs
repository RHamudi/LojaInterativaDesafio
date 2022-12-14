// <auto-generated />
using LojaInterativa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaInterativa.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221201024603_InicialCreate")]
    partial class InicialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LojaInterativa.Models.Categoria", b =>
                {
                    b.Property<int>("idCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nomeCategoria")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("NVARCHAR(180)")
                        .HasColumnName("nomeCategoria");

                    b.HasKey("idCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("LojaInterativa.Models.Fabricante", b =>
                {
                    b.Property<int>("idFabricante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fantasiaFabricante")
                        .HasMaxLength(180)
                        .HasColumnType("NVARCHAR(180)")
                        .HasColumnName("fantasiaFabricante");

                    b.Property<string>("nomeFabricante")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("NVARCHAR(180)")
                        .HasColumnName("nomeFabricante");

                    b.HasKey("idFabricante");

                    b.ToTable("Fabricante");
                });

            modelBuilder.Entity("LojaInterativa.Models.Produto", b =>
                {
                    b.Property<int>("idProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descricaoProduto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR(200)")
                        .HasColumnName("descricaoProduto");

                    b.Property<int>("idCategoria")
                        .HasColumnType("int");

                    b.Property<int>("idFabricante")
                        .HasColumnType("int");

                    b.Property<decimal>("precoProduto")
                        .HasPrecision(18, 2)
                        .HasColumnType("DECIMAL(18,2)")
                        .HasColumnName("precoProduto");

                    b.HasKey("idProduto");

                    b.HasIndex("idCategoria");

                    b.HasIndex("idFabricante");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("LojaInterativa.Models.Produto", b =>
                {
                    b.HasOne("LojaInterativa.Models.Categoria", "Categoria")
                        .WithMany("Produto")
                        .HasForeignKey("idCategoria")
                        .HasConstraintName("FK_PRODUTO_CATEGORIA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaInterativa.Models.Fabricante", "Fabricante")
                        .WithMany("Produto")
                        .HasForeignKey("idFabricante")
                        .HasConstraintName("FK_PRODUTO_FABRICANTE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("LojaInterativa.Models.Categoria", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LojaInterativa.Models.Fabricante", b =>
                {
                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
