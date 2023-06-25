using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCExamProject.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_ExamQuestions_ExamQuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestions_ExamQuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "ExamQuestionId",
                table: "ExamQuestions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamQuestionId",
                table: "ExamQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamQuestionId",
                table: "ExamQuestions",
                column: "ExamQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_ExamQuestions_ExamQuestionId",
                table: "ExamQuestions",
                column: "ExamQuestionId",
                principalTable: "ExamQuestions",
                principalColumn: "Id");
        }
    }
}
