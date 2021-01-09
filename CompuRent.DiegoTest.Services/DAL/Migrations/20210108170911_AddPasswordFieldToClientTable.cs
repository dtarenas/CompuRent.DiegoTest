using Microsoft.EntityFrameworkCore.Migrations;

namespace CompuRent.DiegoTest.Services.DAL.Migrations
{
    public partial class AddPasswordFieldToClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "clients",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "clients");
        }
    }
}
