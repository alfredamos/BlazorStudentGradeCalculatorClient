using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStudentGradeCalculatorClient.Server.Data.Migrations
{
    public partial class addHWScoreAndMakeOtherEntitiesToInheritFromScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Examms_ExammsScoreID",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_HomeWorks_HomeWorkScoreID",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_MidTerms_MidTermScoreID",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "Examms");

            migrationBuilder.DropTable(
                name: "HomeWorks");

            migrationBuilder.DropTable(
                name: "MidTerms");

            migrationBuilder.DropIndex(
                name: "IX_Scores_ExammsScoreID",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_HomeWorkScoreID",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_MidTermScoreID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "ExammsScoreID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "HomeWorkScoreID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "MidTermScoreID",
                table: "Scores");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExammID",
                table: "Scores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeWorkID",
                table: "Scores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MidTermID",
                table: "Scores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentExammsID",
                table: "Scores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentHomeWorkID",
                table: "Scores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentMidTermID",
                table: "Scores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HWScores",
                columns: table => new
                {
                    HWScoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectScore = table.Column<double>(type: "float", nullable: false),
                    SubjectScoreInLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorkScoreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HWScores", x => x.HWScoreID);
                    table.ForeignKey(
                        name: "FK_HWScores_Scores_HomeWorkScoreID",
                        column: x => x.HomeWorkScoreID,
                        principalTable: "Scores",
                        principalColumn: "ScoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_StudentExammsID",
                table: "Scores",
                column: "StudentExammsID");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_StudentHomeWorkID",
                table: "Scores",
                column: "StudentHomeWorkID");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_StudentMidTermID",
                table: "Scores",
                column: "StudentMidTermID");

            migrationBuilder.CreateIndex(
                name: "IX_HWScores_HomeWorkScoreID",
                table: "HWScores",
                column: "HomeWorkScoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Students_StudentExammsID",
                table: "Scores",
                column: "StudentExammsID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Students_StudentHomeWorkID",
                table: "Scores",
                column: "StudentHomeWorkID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Students_StudentMidTermID",
                table: "Scores",
                column: "StudentMidTermID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Students_StudentExammsID",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Students_StudentHomeWorkID",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Students_StudentMidTermID",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "HWScores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_StudentExammsID",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_StudentHomeWorkID",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_StudentMidTermID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "ExammID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "HomeWorkID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "MidTermID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "StudentExammsID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "StudentHomeWorkID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "StudentMidTermID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "ExammsScoreID",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeWorkScoreID",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MidTermScoreID",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Examms",
                columns: table => new
                {
                    ExammID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentExammsID = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examms", x => x.ExammID);
                    table.ForeignKey(
                        name: "FK_Examms_Students_StudentExammsID",
                        column: x => x.StudentExammsID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeWorks",
                columns: table => new
                {
                    HomeWorkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentHomeWorkID = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWorks", x => x.HomeWorkID);
                    table.ForeignKey(
                        name: "FK_HomeWorks_Students_StudentHomeWorkID",
                        column: x => x.StudentHomeWorkID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MidTerms",
                columns: table => new
                {
                    MidTermID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    SchoolIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentMidTermID = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MidTerms", x => x.MidTermID);
                    table.ForeignKey(
                        name: "FK_MidTerms_Students_StudentMidTermID",
                        column: x => x.StudentMidTermID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ExammsScoreID",
                table: "Scores",
                column: "ExammsScoreID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_HomeWorkScoreID",
                table: "Scores",
                column: "HomeWorkScoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_MidTermScoreID",
                table: "Scores",
                column: "MidTermScoreID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examms_StudentExammsID",
                table: "Examms",
                column: "StudentExammsID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_StudentHomeWorkID",
                table: "HomeWorks",
                column: "StudentHomeWorkID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MidTerms_StudentMidTermID",
                table: "MidTerms",
                column: "StudentMidTermID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Examms_ExammsScoreID",
                table: "Scores",
                column: "ExammsScoreID",
                principalTable: "Examms",
                principalColumn: "ExammID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_HomeWorks_HomeWorkScoreID",
                table: "Scores",
                column: "HomeWorkScoreID",
                principalTable: "HomeWorks",
                principalColumn: "HomeWorkID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_MidTerms_MidTermScoreID",
                table: "Scores",
                column: "MidTermScoreID",
                principalTable: "MidTerms",
                principalColumn: "MidTermID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
