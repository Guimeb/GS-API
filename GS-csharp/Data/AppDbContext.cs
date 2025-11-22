using Microsoft.EntityFrameworkCore;
using GS_csharp.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GS_csharp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica a convenção de nomenclatura snake_case (minúsculo) para TODAS as tabelas.
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()!.ToLower());
            }

            // Configuração da Relação N:N (Track <-> Competence)
            modelBuilder.Entity<Track>()
                .HasMany(t => t.Competences)
                .WithMany(c => c.Tracks);

            // Configuração de Foreign Keys (Chaves Estrangeiras)
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Track)
                .WithMany(t => t.Enrollments)
                .HasForeignKey(e => e.TrackId);

            base.OnModelCreating(modelBuilder);
        }
    }
}