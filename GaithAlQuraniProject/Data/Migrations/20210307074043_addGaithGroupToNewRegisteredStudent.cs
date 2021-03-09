using Microsoft.EntityFrameworkCore.Migrations;

namespace GaithAlQuraniProject.Data.Migrations
{
    public partial class addGaithGroupToNewRegisteredStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GaithGroup",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GaithGroup",
                table: "NewRegisteredStudent");
        }
    }
}
