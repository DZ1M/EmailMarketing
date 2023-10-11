using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailMarketing.SenderMail.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "controle");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:unaccent", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "controle_emails",
                schema: "controle",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    smtp = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    porta = table.Column<int>(type: "integer", nullable: false),
                    ssl = table.Column<bool>(type: "boolean", nullable: false),
                    usuario = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    senha = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    limite_diario = table.Column<int>(type: "integer", nullable: false),
                    enviados_hoje = table.Column<int>(type: "integer", nullable: false),
                    data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_controle_emails", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "controle_emails",
                schema: "controle");
        }
    }
}
