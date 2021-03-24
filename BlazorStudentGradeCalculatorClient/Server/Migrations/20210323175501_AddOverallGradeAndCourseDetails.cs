using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStudentGradeCalculatorClient.Server.Migrations
{
    public partial class AddOverallGradeAndCourseDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OverallGradeID",
                table: "MidTerms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OverallGradeID",
                table: "HomeWorks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OverallGradeID",
                table: "Examms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseWeights",
                columns: table => new
                {
                    CourseDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectWeight = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseWeights", x => x.CourseDetailsID);
                });

            migrationBuilder.CreateTable(
                name: "OverallGrades",
                columns: table => new
                {
                    OverallGradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectScore = table.Column<double>(type: "float", nullable: false),
                    SubjectScoreInLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSubjects = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverallGrades", x => x.OverallGradeID);
                    table.ForeignKey(
                        name: "FK_OverallGrades_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MidTerms_OverallGradeID",
                table: "MidTerms",
                column: "OverallGradeID",
                unique: true,
                filter: "[OverallGradeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_OverallGradeID",
                table: "HomeWorks",
                column: "OverallGradeID",
                unique: true,
                filter: "[OverallGradeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Examms_OverallGradeID",
                table: "Examms",
                column: "OverallGradeID",
                unique: true,
                filter: "[OverallGradeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OverallGrades_StudentID",
                table: "OverallGrades",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Examms_OverallGrades_OverallGradeID",
                table: "Examms",
                column: "OverallGradeID",
                principalTable: "OverallGrades",
                principalColumn: "OverallGradeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_OverallGrades_OverallGradeID",
                table: "HomeWorks",
                column: "OverallGradeID",
                principalTable: "OverallGrades",
                principalColumn: "OverallGradeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MidTerms_OverallGrades_OverallGradeID",
                table: "MidTerms",
                column: "OverallGradeID",
                principalTable: "OverallGrades",
                principalColumn: "OverallGradeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examms_OverallGrades_OverallGradeID",
                table: "Examms");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_OverallGrades_OverallGradeID",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_MidTerms_OverallGrades_OverallGradeID",
                table: "MidTerms");

            migrationBuilder.DropTable(
                name: "CourseWeights");

            migrationBuilder.DropTable(
                name: "OverallGrades");

            migrationBuilder.DropIndex(
                name: "IX_MidTerms_OverallGradeID",
                table: "MidTerms");

            migrationBuilder.DropIndex(
                name: "IX_HomeWorks_OverallGradeID",
                table: "HomeWorks");

            migrationBuilder.DropIndex(
                name: "IX_Examms_OverallGradeID",
                table: "Examms");

            migrationBuilder.DropColumn(
                name: "OverallGradeID",
                table: "MidTerms");

            migrationBuilder.DropColumn(
                name: "OverallGradeID",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "OverallGradeID",
                table: "Examms");
        }
    }
}
