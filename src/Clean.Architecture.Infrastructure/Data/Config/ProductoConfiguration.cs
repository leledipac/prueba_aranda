
using Clean.Architecture.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Architecture.Infrastructure.Data.Config;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
  public void Configure(EntityTypeBuilder<Producto> builder)
  {
    builder.Property(p => p.Nombre)
        .HasMaxLength(100)
        .IsRequired();
    builder.Property(p => p.Descripcion)
        .IsRequired();

    /*builder.Property(p => p.Descripcion)
      .HasConversion(
          p => p.Value,
          p => PriorityStatus.FromValue(p));*/
  }
}
