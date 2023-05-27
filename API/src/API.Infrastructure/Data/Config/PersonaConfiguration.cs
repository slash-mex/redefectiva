using API.Core.PersonaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Data.Config;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
  public void Configure(EntityTypeBuilder<Persona> builder)
  {
    builder.Property(p => p.nombre)
        .HasMaxLength(100)
        .IsRequired();

  }
}
