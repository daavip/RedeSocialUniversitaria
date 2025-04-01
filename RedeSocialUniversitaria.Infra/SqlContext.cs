using Microsoft.EntityFrameworkCore;
using RedeSocialUniversitaria.Domain;

namespace RedeSocialUniversitaria.Infra
{
    public class SqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RedeSocialUniversitariaDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração de relacionamentos

            // Relacionamento entre Usuario e Postagem
            modelBuilder.Entity<Postagem>()
                .HasOne(p => p.Autor)
                .WithMany(u => u.Postagens)
                .HasForeignKey(p => p.AutorId);

            // Relacionamento entre Usuario e Comentario
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Autor)
                .WithMany(u => u.Comentarios)
                .HasForeignKey(c => c.AutorId);

            // Relacionamento entre Postagem e Comentario
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Postagem)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(c => c.PostagemId);

            // Relacionamento entre Usuario e Evento
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Organizador)
                .WithMany(u => u.Eventos)
                .HasForeignKey(e => e.OrganizadorId);

            // Relacionamento muitos-para-muitos entre Usuario e Seguidores
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Seguidores)
                .WithMany(u => u.Seguindo)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioSeguidor",
                    j => j.HasOne<Usuario>().WithMany().HasForeignKey("SeguidorId"),
                    j => j.HasOne<Usuario>().WithMany().HasForeignKey("SeguindoId")
                );
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
