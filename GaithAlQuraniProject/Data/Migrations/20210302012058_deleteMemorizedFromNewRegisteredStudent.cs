using Microsoft.EntityFrameworkCore.Migrations;

namespace GaithAlQuraniProject.Data.Migrations
{
    public partial class deleteMemorizedFromNewRegisteredStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemorizedPart",
                table: "NewRegisteredStudent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemorizedPart",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
