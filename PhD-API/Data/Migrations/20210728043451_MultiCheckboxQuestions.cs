using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MultiCheckboxQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Order", "Type" },
                values: new object[] { 15, "15-هل أثر هذا المشروع على تخفيض تكلفة الانفاق الرأسمالي (او من المتوقع تخفيضه)؟ ، في أي التكاليف تم الانخفاض من خلال احد الخيارات التالية", 15, 5 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "QuestionId" },
                values: new object[] { 58, "15-1-الأرض والمباني", 15 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "QuestionId" },
                values: new object[] { 59, "15-2-الآلات والمعدات والمعامل وأجهزة الكمبيوتر", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

        }
    }
}
