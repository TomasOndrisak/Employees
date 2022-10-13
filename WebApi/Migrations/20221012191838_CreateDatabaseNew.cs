using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class CreateDatabaseNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pozicie",
                columns: table => new
                {
                    PoziciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazovPozicie = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozicie", x => x.PoziciaID);
                });

            migrationBuilder.CreateTable(
                name: "PredoslePozicie",
                columns: table => new
                {
                    IDPredoslej = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZamestnanecId = table.Column<int>(type: "int", nullable: false),
                    poziciaId = table.Column<int>(type: "int", nullable: false),
                    datumNastupu = table.Column<DateTime>(type: "date", nullable: false),
                    datumUkoncenia = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredoslePozicie", x => x.IDPredoslej);
                    table.ForeignKey(
                        name: "FK_PredoslePozicie_Pozicie_poziciaId",
                        column: x => x.poziciaId,
                        principalTable: "Pozicie",
                        principalColumn: "PoziciaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamestnanci",
                columns: table => new
                {
                    ZamestnanecID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meno = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Priezvisko = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    adresa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DatumNarodenia = table.Column<DateTime>(type: "date", nullable: false),
                    DatumNastupu = table.Column<DateTime>(type: "date", nullable: false),
                    archivovany = table.Column<bool>(type: "bit", nullable: false),
                    PoziciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamestnanci", x => x.ZamestnanecID);
                    table.ForeignKey(
                        name: "FK_Zamestnanci_Pozicie_PoziciaId",
                        column: x => x.PoziciaId,
                        principalTable: "Pozicie",
                        principalColumn: "PoziciaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredoslePozicie_poziciaId",
                table: "PredoslePozicie",
                column: "poziciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamestnanci_PoziciaId",
                table: "Zamestnanci",
                column: "PoziciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredoslePozicie");

            migrationBuilder.DropTable(
                name: "Zamestnanci");

            migrationBuilder.DropTable(
                name: "Pozicie");
        }
    }
}
