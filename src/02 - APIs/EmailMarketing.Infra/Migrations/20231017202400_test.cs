using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailMarketing.Infra.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "marketing");

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
                    nome = table.Column<string>(type: "varchar(150)", nullable: true),
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
                name: "campanhas_contatos",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "pastas",
                schema: "marketing");

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
