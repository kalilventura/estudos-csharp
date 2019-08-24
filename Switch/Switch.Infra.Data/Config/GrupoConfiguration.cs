using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(grupo => grupo.Id);
            builder.Property(grupo => grupo.Nome)
                            .IsRequired().HasMaxLength(100);
            builder.Property(grupo => grupo.Descricao)
                            .IsRequired().HasMaxLength(100);
            builder.Property(grupo => grupo.UrlFoto)
                             .IsRequired().HasMaxLength(1000);
            builder.HasMany(grupo => grupo.Postagens)
                            .WithOne(postagem => postagem.Grupo);
        }
    }
}