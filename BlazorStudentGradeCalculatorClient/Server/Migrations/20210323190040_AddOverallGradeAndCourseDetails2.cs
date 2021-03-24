using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStudentGradeCalculatorClient.Server.Migrations
{
    public partial class AddOverallGradeAndCourseDetails2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseDetailsID",
                table: "CourseWeights",
                newName: "CourseDetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseDetailID",
                table: "CourseWeights",
                newName: "CourseDetailsID");
        }
    }
}
