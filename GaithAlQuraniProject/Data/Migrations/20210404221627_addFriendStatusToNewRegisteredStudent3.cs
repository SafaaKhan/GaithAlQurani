using Microsoft.EntityFrameworkCore.Migrations;

namespace GaithAlQuraniProject.Data.Migrations
{
    public partial class addFriendStatusToNewRegisteredStudent3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FriendStatus",
                table: "NewRegisteredStudent",
                newName: "FriendStatusT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FriendStatusT",
                table: "NewRegisteredStudent",
                newName: "FriendStatus");
        }
    }
}
