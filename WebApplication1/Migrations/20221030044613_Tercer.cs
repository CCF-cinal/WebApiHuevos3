using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiHuevos3.Migrations
{
    public partial class Tercer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Edad",
                table: "Huevos",
                newName: "Dias");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Encargados",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dias",
                table: "Huevos",
                newName: "Edad");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Encargados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
