using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiHuevos3.Migrations
{
    public partial class Denuevo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Huevos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Huevos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncargadoId = table.Column<int>(type: "int", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huevos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huevos_Encargados_EncargadoId",
                        column: x => x.EncargadoId,
                        principalTable: "Encargados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huevos_EncargadoId",
                table: "Huevos",
                column: "EncargadoId");
        }
    }
}
