using Microsoft.EntityFrameworkCore.Migrations;

namespace GaithAlQuraniProject.Data.Migrations
{
    public partial class addProgramConditionsDefinitionToModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramConditionsDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefinitionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefinitionInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramConditionsDefinitions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramConditionsDefinitions");
        }
    }
}
