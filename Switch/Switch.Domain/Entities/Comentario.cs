using System;

namespace Switch.Domain.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Comentario()
        {
            DataPublicacao = DateTime.Now;
        }

        public void SetUsuario(Usuario usuario)
        {
            if(usuario != null)
            {
                Usuario = usuario;
            }
        }
    }
    
}
