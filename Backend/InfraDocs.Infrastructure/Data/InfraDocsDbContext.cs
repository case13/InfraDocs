using InfraDocs.Domain.Entities;
using InfraDocs.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InfraDocs.Infrastructure.Data
{
    public class InfraDocsDbContext : DbContext
    {
        public InfraDocsDbContext(DbContextOptions<InfraDocsDbContext> options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Organizacao> Organizacoes => Set<Organizacao>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Pessoa> Pessoas => Set<Pessoa>();
        public DbSet<RequerimentoSuspensaoRestricao> RequerimentosSuspensaoRestricao => Set<RequerimentoSuspensaoRestricao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organizacao>().HasData(
            new 
            {
               Id = 1,
               Nome = "Case13 - Soluções Tecnológicas ME",
               Documento = "32230441000176",
               TipoDocumento = TipoDocumentoEnum.CNPJ,
               StatusOrganizacao = StatusBasicoEnum.Ativo,
               CreatedAt = new DateTime(2025, 1, 1),
               IsActive = true
            }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new 
                {
                    Id = 1,
                    OrganizacaoId = 1,
                    Nome = "Anderson Gonçalves",
                    Email = "anderson.infosistemas@gmail.com",
                    Documento = "64585972234",
                    TipoDocumento = TipoDocumentoEnum.CPF,
                    TipoUsuario = TipoUsuarioEnum.Administrador,
                    StatusUsuario = StatusBasicoEnum.Ativo,
                    CreatedAt = new DateTime(2025, 1, 1),
                    IsActive = true
                }
            );


            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());


            modelBuilder.Entity<RefreshToken>(e =>
            {
                e.HasOne(x => x.Usuario)
                    .WithMany()
                    .HasForeignKey(x => x.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.Property(x => x.Token)
                    .IsRequired()
                    .HasMaxLength(500);
            });


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
