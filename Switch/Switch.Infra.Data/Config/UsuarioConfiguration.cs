using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(usuario => usuario.Id);
            builder.Property(usuario => usuario.Nome).HasMaxLength(400).IsRequired();
            builder.Property(usuario => usuario.Sobrenome).HasMaxLength(400).IsRequired();
            builder.Property(usuario => usuario.Email).HasMaxLength(400).IsRequired();
            builder.Property(usuario => usuario.Senha).HasMaxLength(400).IsRequired();
            builder.Property(usuario => usuario.Sexo).IsRequired();
            builder.Property(usuario => usuario.UrlFoto).HasMaxLength(400).IsRequired();
            builder.Property(usuario => usuario.DataNascimento).IsRequired();
            builder.HasOne(usuario => usuario.Identificacao)
                           .WithOne(identificacao => identificacao.Usuario)
                           .HasForeignKey<Identificacao>(identificacao => identificacao.UsuarioId);
            builder.HasMany(usuario => usuario.Postagens).WithOne(postagem => postagem.Usuario);
        }
    }
}
