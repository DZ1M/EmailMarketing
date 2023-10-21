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
                    { new Guid("0b9178c6-926f-43c7-b849-0ecd292f30e5"), true, "Campanha", "Read" },
                    { new Guid("13c7e4b6-6565-4c2a-a851-56b6ccf47e17"), true, "Pasta", "Delete" },
                    { new Guid("1aa3f85a-11d0-4473-9a74-19c25767973a"), true, "Campanha", "Delete" },
                    { new Guid("49ffa2e4-64bf-4ca2-a14d-18d96d3eede6"), true, "Modelo", "Create" },
                    { new Guid("5a550165-04b5-4de8-9203-8e0ebf099c7e"), true, "Pasta", "Update" },
                    { new Guid("622b1f13-9256-4abb-8e86-b8cb3396b524"), true, "Modelo", "Read" },
                    { new Guid("68daa0cf-b018-4291-aaf1-da81e7501e82"), true, "Contato", "Delete" },
                    { new Guid("7438c5ca-28a5-4fef-b315-0f152984c91b"), true, "Contato", "Update" },
                    { new Guid("7ae7c925-00e8-4abe-bc1c-102e0a87a7d2"), true, "Contato", "Create" },
                    { new Guid("7dcfd277-66fd-4c48-90d3-6658860edc4e"), true, "Contato", "Read" },
                    { new Guid("8173638e-4297-44cd-a247-04538ef85f64"), true, "Pasta", "Create" },
                    { new Guid("b4e4888a-8f52-4119-b5a4-80bf88b37c2c"), true, "Modelo", "Delete" },
                    { new Guid("de48cddc-8260-4bee-b781-a89a9c157413"), true, "Pasta", "Read" },
                    { new Guid("e100c931-63d1-4d31-be14-97f3d8d2b2c6"), true, "Campanha", "Create" },
                    { new Guid("f259fb96-bd94-43af-81d5-7663d7b4b6cb"), true, "Modelo", "Update" },
                    { new Guid("faae2d77-3123-4079-8518-f927bdeb635b"), true, "Campanha", "Update" }
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
