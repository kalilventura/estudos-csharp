using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class PostagemConfiguration : IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            builder.HasKey(postagem => postagem.Id);
            builder.Property(postagem => postagem.DataPublicacao).IsRequired();
            builder.Property(postagem => postagem.Texto).IsRequired().HasMaxLength(400);
            builder.HasOne(postagem => postagem.Usuario).WithMany(usuario => usuario.Postagens);

        }
    }
}
