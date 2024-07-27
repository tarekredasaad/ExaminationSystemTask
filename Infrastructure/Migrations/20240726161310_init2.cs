using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assessment_text_Exams_ExamId",
                table: "assessment_text");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_text_Questions_QuestionId",
                table: "assessment_text");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_Courseid",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assessment_text",
                table: "assessment_text");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "assessment_text");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "assessment_text");

            migrationBuilder.RenameTable(
                name: "assessment_text",
                newName: "ExamQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_assessment_text_QuestionId",
                table: "ExamQuestions",
                newName: "IX_ExamQuestions_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_assessment_text_ExamId",
                table: "ExamQuestions",
                newName: "IX_ExamQuestions_ExamId");

            migrationBuilder.AlterColumn<int>(
                name: "Courseid",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_GroupId",
                table: "Instructors",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Groups_GroupId",
                table: "Instructors",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_Courseid",
                table: "Students",
                column: "Courseid",
                principalTable: "Courses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Groups_GroupId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_Courseid",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_GroupId",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Instructors");

            migrationBuilder.RenameTable(
                name: "ExamQuestions",
                newName: "assessment_text");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestions_QuestionId",
                table: "assessment_text",
                newName: "IX_assessment_text_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestions_ExamId",
                table: "assessment_text",
                newName: "IX_assessment_text_ExamId");

            migrationBuilder.AlterColumn<int>(
                name: "Courseid",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Questions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Questions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Instructors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Instructors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Exams",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Exams",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Choices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Choices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "assessment_text",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "assessment_text",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_assessment_text",
                table: "assessment_text",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_text_Exams_ExamId",
                table: "assessment_text",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_text_Questions_QuestionId",
                table: "assessment_text",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_Courseid",
                table: "Students",
                column: "Courseid",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
