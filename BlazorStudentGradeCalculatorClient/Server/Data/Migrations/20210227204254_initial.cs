using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStudentGradeCalculatorClient.Server.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Examms",
                columns: table => new
                {
                    ExammID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentExammsID = table.Column<int>(type: "int", nullable: false)
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
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentHomeWorkID = table.Column<int>(type: "int", nullable: false)
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
                    SchoolIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    StudentMidTermID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ScoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectScore = table.Column<double>(type: "float", nullable: false),
                    SubjectScoreInLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MidTermScoreID = table.Column<int>(type: "int", nullable: false),
                    ExammsScoreID = table.Column<int>(type: "int", nullable: false),
                    HomeWorkScoreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ScoreID);
                    table.ForeignKey(
                        name: "FK_Scores_Examms_ExammsScoreID",
                        column: x => x.ExammsScoreID,
                        principalTable: "Examms",
                        principalColumn: "ExammID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Scores_HomeWorks_HomeWorkScoreID",
                        column: x => x.HomeWorkScoreID,
                        principalTable: "HomeWorks",
                        principalColumn: "HomeWorkID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Scores_MidTerms_MidTermScoreID",
                        column: x => x.MidTermScoreID,
                        principalTable: "MidTerms",
                        principalColumn: "MidTermID",
                        onDelete: ReferentialAction.NoAction);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Examms");

            migrationBuilder.DropTable(
                name: "HomeWorks");

            migrationBuilder.DropTable(
                name: "MidTerms");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
