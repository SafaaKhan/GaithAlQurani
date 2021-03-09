using Microsoft.EntityFrameworkCore.Migrations;

namespace GaithAlQuraniProject.Data.Migrations
{
    public partial class addMoreFieldsToNewRegisteredStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SuitableTimeExam",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CallingProgramExam",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ExamTeacher",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherNotes",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamTeacher",
                table: "NewRegisteredStudent");

            migrationBuilder.DropColumn(
                name: "TeacherNotes",
                table: "NewRegisteredStudent");

            migrationBuilder.AlterColumn<string>(
                name: "SuitableTimeExam",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CallingProgramExam",
                table: "NewRegisteredStudent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
