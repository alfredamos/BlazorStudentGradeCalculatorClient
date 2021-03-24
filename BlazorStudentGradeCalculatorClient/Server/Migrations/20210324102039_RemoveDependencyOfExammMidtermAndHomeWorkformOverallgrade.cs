using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStudentGradeCalculatorClient.Server.Migrations
{
    public partial class RemoveDependencyOfExammMidtermAndHomeWorkformOverallgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
