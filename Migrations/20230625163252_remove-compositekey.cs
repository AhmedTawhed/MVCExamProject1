using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCExamProject.Migrations
{
    /// <inheritdoc />
    public partial class removecompositekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserExams",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_UserId",
                table: "UserExams",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_UserExams_UserId",
                table: "UserExams");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserExams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                columns: new[] { "UserId", "ExamId" });
        }
    }
}
