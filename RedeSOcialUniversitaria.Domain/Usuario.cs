namespace RedeSocialUniversitaria.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
        public ICollection<Usuario> Seguidores { get; set; }
        public ICollection<Usuario> Seguindo { get; set; }
        public ICollection<Postagem> Postagens { get; set; }
        public ICollection<Evento>  Eventos { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
    }
}
