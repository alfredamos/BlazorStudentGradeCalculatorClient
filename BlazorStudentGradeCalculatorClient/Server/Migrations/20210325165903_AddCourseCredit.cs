using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStudentGradeCalculatorClient.Server.Migrations
{
    public partial class AddCourseCredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCredits",
                columns: table => new
                {
                    CourseCreditID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeCredit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCredits", x => x.CourseCreditID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCredits");
        }
    }
}
