using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraDocs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsuarioInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizacao",
                columns: new[] { "Id", "CreatedAt", "Documento", "IsActive", "Nome", "StatusOrganizacao", "TipoDocumento", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "32230441000176", true, "Case13 - Soluções Tecnológicas ME", 1, 2, null });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "CreatedAt", "Documento", "Email", "IsActive", "Nome", "OrganizacaoId", "StatusUsuario", "TipoDocumento", "TipoUsuario", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "64585972234", "anderson.infosistemas@gmail.com", true, "Anderson Gonçalves", 1, 1, 1, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizacao",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
