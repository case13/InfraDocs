using InfraDocs.Application.Services.Implementations;
using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Domain.Currents.Interfaces;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Infrastructure.Current.Implementations;
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
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<InfraDocsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repositórios
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IRequerimentoSuspensaoRestricaoRepository, RequerimentoSuspensaoRestricaoRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();


            // Currents
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<ICurrentOrganizacao, CurrentOrganizacao>();

            // Services
            services.AddScoped<IOrganizacaoService, OrganizacaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IRequerimentoSuspensaoRestricaoService, RequerimentoSuspensaoRestricaoService>();

            // TOKEN SERVICE
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
