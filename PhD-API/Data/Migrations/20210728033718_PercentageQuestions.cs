using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PercentageQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Header", "Order", "Type" },
                values: new object[] { 14, "14- هل أثر هذا المشروع على تخفيض تكلفة الانفاق الجاري ؟", null, 14, 4 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "QuestionId" },
                values: new object[,]
                {
                    { 53, "14-1-نسبة الانخفاض في تكلفة العمالة %", 14 },
                    { 54, "14-2-نسبة الانخفاض في تكلفة المدخلات الوسيطة %", 14 },
                    { 55, "14-3-نسبة الانخفاض في استهلاك الوقود (غاز/ كهرباء) %", 14 },
                    { 56, "14-4-نسبة الانخفاض في استهلاك المياه %", 14 },
                    { 57, "14-5-مصروفات عامة أخرى %", 14 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

        }
    }
}
