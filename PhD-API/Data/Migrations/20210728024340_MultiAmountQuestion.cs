using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MultiAmountQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Header", "Order", "Type" },
                values: new object[] { 4, "4- إجمالي التمويل المتاح لهذا المشروع (بالجنيه المصري)", null, 4, 3 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "QuestionId" },
                values: new object[] { 51, "4-1- التمويل المتاح من أكاديمية البحث العلمي (بالجنيه المصري)", 4 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "QuestionId" },
                values: new object[] { 52, "4-2- التمويل المتاح من مصادر أخرى (بالجنيه المصري)", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

        
        }
    }
}
