using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostAppApi.Infrastructure.Migrations
{
    public partial class AdicionadoRolesparausuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Users");
        }
    }
}
