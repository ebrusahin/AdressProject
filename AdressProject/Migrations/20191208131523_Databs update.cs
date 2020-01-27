using Microsoft.EntityFrameworkCore.Migrations;

namespace AdressProject.Migrations
{
    public partial class Databsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdressTipi",
                table: "AdressTypes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Adresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "AdressTipi",
                table: "AdressTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
