using InfraDocs.Shared.Authorizations;
using InfraDocs.Api.Authorization.Requirements;
using InfraDocs.Api.Configurations;
using InfraDocs.Infrastructure.Configurations;
using InfraDocs.Shared.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Controllers
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        // Infrastructure
        builder.Services.AddInfrastructure(builder.Configuration);

        // Swagger
        builder.Services.AddSwaggerConfiguration();

        // Auth
        builder.Services.AddJwtAuthentication(builder.Configuration);

        builder.Services.AddAuthorizationConfiguration();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InfraDocs.Api v1");
                c.RoutePrefix = "swagger";
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
