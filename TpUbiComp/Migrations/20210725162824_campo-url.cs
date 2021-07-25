using Microsoft.EntityFrameworkCore.Migrations;

namespace TpUbiComp.Migrations
{
    public partial class campourl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "ApplicationLocale",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "ApplicationLocale");
        }
    }
}
