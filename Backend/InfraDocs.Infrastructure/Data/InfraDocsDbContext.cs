using InfraDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InfraDocs.Infrastructure.Data
{
    public class InfraDocsDbContext : DbContext
    {
        public InfraDocsDbContext(DbContextOptions<InfraDocsDbContext> options) : base(options) { }

        public DbSet<Organizacao> Organizacoes => Set<Organizacao>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Pessoa> Pessoas => Set<Pessoa>();
        public DbSet<RequerimentoSuspensaoRestricao> RequerimentosSuspensaoRestricao => Set<RequerimentoSuspensaoRestricao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());

            modelBuilder.Entity<Usuario>(e =>
            {
                e.HasOne(x => x.Organizacao)
                    .WithMany()
                    .HasForeignKey(x => x.OrganizacaoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Pessoa>(e =>
            {
                e.HasOne(x => x.Organizacao)
                    .WithMany()
                    .HasForeignKey(x => x.OrganizacaoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RequerimentoSuspensaoRestricao>(e =>
            {
                e.HasOne(x => x.Organizacao)
                    .WithMany()
                    .HasForeignKey(x => x.OrganizacaoId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Pessoa)
                    .WithMany()
                    .HasForeignKey(x => x.PessoaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
