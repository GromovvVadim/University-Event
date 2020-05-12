using Microsoft.EntityFrameworkCore.Migrations;

namespace University_Event.Persistence.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
