using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStudentGradeCalculatorClient.Server.Migrations
{
    public partial class ForeignKeysOfExammMidtermAndHomeWorkAreNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examms_Students_StudentID",
                table: "Examms");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_Students_StudentID",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_MidTerms_Students_StudentID",
                table: "MidTerms");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "MidTerms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "HomeWorks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Examms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Examms_Students_StudentID",
                table: "Examms",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_Students_StudentID",
                table: "HomeWorks",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MidTerms_Students_StudentID",
                table: "MidTerms",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examms_Students_StudentID",
                table: "Examms");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_Students_StudentID",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_MidTerms_Students_StudentID",
                table: "MidTerms");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "MidTerms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "HomeWorks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Examms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Examms_Students_StudentID",
                table: "Examms",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_Students_StudentID",
                table: "HomeWorks",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MidTerms_Students_StudentID",
                table: "MidTerms",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
