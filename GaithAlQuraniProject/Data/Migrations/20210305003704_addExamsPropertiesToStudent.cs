using Microsoft.EntityFrameworkCore.Migrations;

namespace GaithAlQuraniProject.Data.Migrations
{
    public partial class addExamsPropertiesToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallingProgramExam",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuitableTimeExam",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallingProgramExam",
                table: "NewRegisteredStudent");

            migrationBuilder.DropColumn(
                name: "SuitableTimeExam",
                table: "NewRegisteredStudent");
        }
    }
}
