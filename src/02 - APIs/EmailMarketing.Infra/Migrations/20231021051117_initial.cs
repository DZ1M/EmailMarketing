using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmailMarketing.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "marketing");

            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:unaccent", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "contatos",
                schema: "marketing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    email = table.Column<string>(type: "varchar(150)", nullable: true),
                    telefone = table.Column<string>(type: "varchar(25)", nullable: true),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    criado_por = table.Column<Guid>(type: "uuid", nullable: false),
                    atualizado_por = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.id);
                });

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
                name: "modelos",
                schema: "marketing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    texto = table.Column<string>(type: "text", nullable: false),
                    tipo = table.Column<string>(type: "varchar(25)", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    criado_por = table.Column<Guid>(type: "uuid", nullable: false),
                    atualizado_por = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pastas",
                schema: "marketing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    criado_por = table.Column<Guid>(type: "uuid", nullable: false),
                    atualizado_por = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastas", x => x.id);
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
                name: "campanhas",
                schema: "marketing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    tipo_mensagem = table.Column<string>(type: "varchar(25)", nullable: false),
                    nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    titulo = table.Column<string>(type: "varchar(250)", nullable: false),
                    data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id_modelo = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    criado_por = table.Column<Guid>(type: "uuid", nullable: false),
                    atualizado_por = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campanhas", x => x.id);
                    table.ForeignKey(
                        name: "FK_campanhas_modelos_id_modelo",
                        column: x => x.id_modelo,
                        principalSchema: "marketing",
                        principalTable: "modelos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contatos_pastas",
                schema: "marketing",
                columns: table => new
                {
                    id_contato = table.Column<Guid>(type: "uuid", nullable: false),
                    id_pasta = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos_pastas", x => new { x.id_contato, x.id_pasta });
                    table.ForeignKey(
                        name: "FK_contatos_pastas_contatos_id_contato",
                        column: x => x.id_contato,
                        principalSchema: "marketing",
                        principalTable: "contatos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contatos_pastas_pastas_id_pasta",
                        column: x => x.id_pasta,
                        principalSchema: "marketing",
                        principalTable: "pastas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "campanhas_contatos",
                schema: "marketing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    id_mensagem = table.Column<Guid>(type: "uuid", nullable: false),
                    id_contato = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo = table.Column<string>(type: "varchar(150)", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campanhas_contatos", x => x.id);
                    table.ForeignKey(
                        name: "FK_campanhas_contatos_campanhas_id_mensagem",
                        column: x => x.id_mensagem,
                        principalSchema: "marketing",
                        principalTable: "campanhas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_campanhas_contatos_contatos_id_contato",
                        column: x => x.id_contato,
                        principalSchema: "marketing",
                        principalTable: "contatos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "campanhas_pastas",
                schema: "marketing",
                columns: table => new
                {
                    id_campanha = table.Column<Guid>(type: "uuid", nullable: false),
                    id_pasta = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campanhas_pastas", x => new { x.id_campanha, x.id_pasta });
                    table.ForeignKey(
                        name: "FK_campanhas_pastas_campanhas_id_campanha",
                        column: x => x.id_campanha,
                        principalSchema: "marketing",
                        principalTable: "campanhas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_campanhas_pastas_pastas_id_pasta",
                        column: x => x.id_pasta,
                        principalSchema: "marketing",
                        principalTable: "pastas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "campanhas_contatos_acoes",
                schema: "marketing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    acao = table.Column<string>(type: "varchar(25)", nullable: false),
                    id_campanha_contato = table.Column<Guid>(type: "uuid", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campanhas_contatos_acoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_campanhas_contatos_acoes_campanhas_contatos_id_campanha_con~",
                        column: x => x.id_campanha_contato,
                        principalSchema: "marketing",
                        principalTable: "campanhas_contatos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "permissoes",
                columns: new[] { "id", "default_role", "nome", "valor" },
                values: new object[,]
                {
                    { new Guid("04c1c55b-91dd-4324-8daf-feaac5dd9b02"), false, "Pasta", "Update" },
                    { new Guid("0733835e-e551-40a5-8f43-e02f93e9781b"), false, "Contato", "Update" },
                    { new Guid("07743798-8f8f-413f-b80b-1b7ef556c6fb"), false, "Modelo", "Update" },
                    { new Guid("0c2e6d73-4221-4436-8198-8cfc54cb3c9f"), false, "Pasta", "Delete" },
                    { new Guid("1f82f594-b209-4c0d-8fd0-714886e55c71"), false, "Modelo", "Delete" },
                    { new Guid("33f2559c-050d-404d-a832-fc9e6f101e0d"), false, "Contato", "Create" },
                    { new Guid("39dd716f-bc97-457f-8184-d91ebda93b89"), false, "Modelo", "Create" },
                    { new Guid("3ac31129-b587-422b-8d2d-908c9ad8aec4"), false, "Campanha", "Update" },
                    { new Guid("40d7bcbe-c075-4bb8-b64c-b21996728ac4"), false, "Campanha", "Create" },
                    { new Guid("433414bf-89be-43a7-bb2e-9503030db2d4"), false, "Pasta", "Read" },
                    { new Guid("5c924f23-fffd-4b05-a233-886eeeecc10b"), false, "Campanha", "Delete" },
                    { new Guid("6fb8bba8-9e40-425c-bf01-306bbd9ca5bb"), false, "Contato", "Delete" },
                    { new Guid("829001da-3f4d-4a87-9bcd-f343de65a889"), false, "Campanha", "Read" },
                    { new Guid("a3dc6c38-233f-47f3-b367-0bf133554d63"), false, "Contato", "Read" },
                    { new Guid("ba36b8a8-8012-4f70-8968-c2f1c90e7aef"), false, "Pasta", "Create" },
                    { new Guid("d4b03b5a-176e-47c1-9a48-cbd5265ea75e"), false, "Modelo", "Read" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_campanhas_id_modelo",
                schema: "marketing",
                table: "campanhas",
                column: "id_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_campanhas_contatos_codigo",
                schema: "marketing",
                table: "campanhas_contatos",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_campanhas_contatos_id_contato",
                schema: "marketing",
                table: "campanhas_contatos",
                column: "id_contato");

            migrationBuilder.CreateIndex(
                name: "IX_campanhas_contatos_id_mensagem",
                schema: "marketing",
                table: "campanhas_contatos",
                column: "id_mensagem");

            migrationBuilder.CreateIndex(
                name: "IX_campanhas_contatos_acoes_id_campanha_contato",
                schema: "marketing",
                table: "campanhas_contatos_acoes",
                column: "id_campanha_contato");

            migrationBuilder.CreateIndex(
                name: "IX_campanhas_pastas_id_pasta",
                schema: "marketing",
                table: "campanhas_pastas",
                column: "id_pasta");

            migrationBuilder.CreateIndex(
                name: "IX_contatos_pastas_id_pasta",
                schema: "marketing",
                table: "contatos_pastas",
                column: "id_pasta");

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
                name: "campanhas_contatos_acoes",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "campanhas_pastas",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "contatos_pastas",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "usuarios_empresas",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "usuarios_permissoes",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "campanhas_contatos",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "pastas",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "empresas",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "permissoes",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "campanhas",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "contatos",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "modelos",
                schema: "marketing");
        }
    }
}
