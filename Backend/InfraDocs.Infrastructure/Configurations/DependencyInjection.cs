using AutoMapper;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Infrastructure.Data;
using InfraDocs.Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace InfraDocs.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InfraDocsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Repositórios
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IRequerimentoSuspensaoRestricaoRepository, RequerimentoSuspensaoRestricaoRepository>();

            return services;
        }
    }
}
