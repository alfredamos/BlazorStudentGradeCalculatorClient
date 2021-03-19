using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStudentGradeCalculatorClient.Server.Migrations
{
    public partial class AddNumberOfHomeWorksToHomeWorkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HWScores_HomeWorks_HomeWorkID",
                table: "HWScores");

            migrationBuilder.AlterColumn<int>(
                name: "HomeWorkID",
                table: "HWScores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfHomeWorks",
                table: "HomeWorks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_HWScores_HomeWorks_HomeWorkID",
                table: "HWScores",
                column: "HomeWorkID",
                principalTable: "HomeWorks",
                principalColumn: "HomeWorkID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HWScores_HomeWorks_HomeWorkID",
                table: "HWScores");

            migrationBuilder.DropColumn(
                name: "NumberOfHomeWorks",
                table: "HomeWorks");

            migrationBuilder.AlterColumn<int>(
                name: "HomeWorkID",
                table: "HWScores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HWScores_HomeWorks_HomeWorkID",
                table: "HWScores",
                column: "HomeWorkID",
                principalTable: "HomeWorks",
                principalColumn: "HomeWorkID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
