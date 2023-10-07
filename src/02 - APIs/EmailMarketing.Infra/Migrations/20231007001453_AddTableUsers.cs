using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailMarketing.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTableUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "empresas",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissoes",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    nome = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    valor = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    default_role = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    senha = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    url_perfil = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios_empresas",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    id_usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios_empresas", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_empresas_empresas_id_empresa",
                        column: x => x.id_empresa,
                        principalSchema: "auth",
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuarios_empresas_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "auth",
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios_permissoes",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    id_usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    id_permissao = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios_permissoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_permissoes_permissoes_id_permissao",
                        column: x => x.id_permissao,
                        principalSchema: "auth",
                        principalTable: "permissoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuarios_permissoes_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "auth",
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_empresas_id_empresa",
                schema: "auth",
                table: "usuarios_empresas",
                column: "id_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_empresas_id_usuario",
                schema: "auth",
                table: "usuarios_empresas",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_permissoes_id_permissao",
                schema: "auth",
                table: "usuarios_permissoes",
                column: "id_permissao");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_permissoes_id_usuario",
                schema: "auth",
                table: "usuarios_permissoes",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios_empresas",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "usuarios_permissoes",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "empresas",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "permissoes",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "auth");
        }
    }
}
