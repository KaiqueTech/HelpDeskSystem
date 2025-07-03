using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HelpDeskSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NumberClient = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "tb_Calleds",
                columns: table => new
                {
                    IdCalled = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    TechnicalId = table.Column<int>(type: "integer", nullable: false),
                    Technical = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateClose = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Calleds", x => x.IdCalled);
                    table.ForeignKey(
                        name: "FK_tb_Calleds_tb_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tb_Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Messages",
                columns: table => new
                {
                    IdMessage = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CalledId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DateHours = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Origin = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Messages", x => x.IdMessage);
                    table.ForeignKey(
                        name: "FK_tb_Messages_tb_Calleds_CalledId",
                        column: x => x.CalledId,
                        principalTable: "tb_Calleds",
                        principalColumn: "IdCalled",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Calleds_ClientId",
                table: "tb_Calleds",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Messages_CalledId",
                table: "tb_Messages",
                column: "CalledId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Messages");

            migrationBuilder.DropTable(
                name: "tb_Calleds");

            migrationBuilder.DropTable(
                name: "tb_Clients");
        }
    }
}
