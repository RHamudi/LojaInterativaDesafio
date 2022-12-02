using LojaInterativa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaInterativa.Data.Mappings
{
    public class FabricanteMap : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.ToTable("Fabricante");

            builder.HasKey(x => x.idFabricante);
            builder.Property(x => x.idFabricante)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.nomeFabricante)
                .IsRequired()
                .HasColumnName("nomeFabricante")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(180);

            builder.Property(x => x.categoria1)
                .IsRequired()
                .HasColumnName("categoria1")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.categoria2)
                .IsRequired()
                .HasColumnName("categoria2")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.categoria3)
                .IsRequired()
                .HasColumnName("categoria3")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);
        }
    }
}