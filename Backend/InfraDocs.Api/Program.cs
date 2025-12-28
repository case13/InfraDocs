using InfraDocs.Infrastructure.Configurations;
using InfraDocs.Api.Configurations;
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
        builder.Services
        .AddAuthentication(options =>
        {
           options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
           options.TokenValidationParameters = new TokenValidationParameters
           {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
              ValidAudience = builder.Configuration["JwtSettings:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)
              ),

            ClockSkew = TimeSpan.Zero
           };
        });
        builder.Services.AddAuthorization();

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
