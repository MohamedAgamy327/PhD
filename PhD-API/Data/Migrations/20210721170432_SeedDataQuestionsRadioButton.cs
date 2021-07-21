using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedDataQuestionsRadioButton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Header", "Type" },
                values: new object[] { 1, "3- نوع النشاط البحثى:", null, 0 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Header", "Type" },
                values: new object[] { 2, "7- مستوى التطبيق البحثى", null, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 88, 63, 15, 172, 186, 77, 168, 4, 131, 107, 4, 16, 150, 37, 4, 248, 89, 71, 108, 208, 40, 155, 178, 112, 178, 39, 204, 157, 83, 18, 114, 186, 38, 164, 149, 247, 64, 15, 181, 156, 124, 1, 209, 136, 180, 88, 208, 139, 239, 145, 28, 219, 43, 52, 248, 89, 250, 182, 170, 204, 158, 97, 155, 35 }, new byte[] { 39, 119, 254, 63, 155, 89, 79, 199, 71, 235, 50, 46, 212, 141, 242, 185, 146, 159, 118, 95, 201, 9, 100, 44, 137, 115, 237, 129, 230, 205, 193, 96, 196, 141, 170, 175, 81, 166, 207, 234, 64, 207, 51, 16, 119, 136, 85, 251, 56, 129, 79, 129, 42, 152, 75, 157, 88, 252, 85, 1, 244, 147, 83, 61, 119, 213, 203, 135, 171, 14, 148, 116, 92, 20, 3, 253, 175, 101, 169, 74, 177, 91, 243, 80, 236, 2, 138, 81, 81, 60, 203, 243, 41, 179, 119, 234, 231, 15, 139, 162, 10, 195, 173, 124, 54, 76, 130, 200, 17, 33, 52, 139, 31, 62, 78, 107, 36, 31, 182, 36, 89, 8, 242, 244, 229, 242, 99, 167 } });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "QuestionId" },
                values: new object[,]
                {
                    { 1, "بحث أساسي", 1 },
                    { 2, "بحث تطبيقي", 1 },
                    { 3, "تطوير تجريبي ", 1 },
                    { 4, " مستوى الشركة (أو المؤسسة الانتاجية ))", 2 },
                    { 5, "مستوى الصناعة  (أو القطاع الانتاجى )", 2 },
                    { 6, "مستوى الاقتصاد الوطنى ", 2 },
                    { 7, "مستوى اقليمى أو دولى  (المشروعات المشتركة ) ", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 207, 91, 37, 172, 64, 83, 112, 130, 84, 186, 246, 70, 227, 19, 0, 80, 229, 40, 197, 137, 160, 132, 59, 34, 159, 236, 222, 161, 131, 50, 3, 142, 56, 38, 101, 85, 59, 124, 227, 170, 231, 194, 66, 251, 33, 248, 111, 198, 8, 77, 123, 214, 77, 25, 182, 254, 141, 113, 244, 192, 182, 70, 229 }, new byte[] { 79, 24, 58, 133, 40, 99, 163, 246, 75, 236, 37, 194, 98, 189, 174, 132, 195, 160, 252, 83, 253, 224, 160, 9, 120, 65, 84, 255, 190, 144, 139, 45, 191, 213, 184, 146, 87, 178, 249, 179, 20, 207, 79, 32, 231, 87, 215, 216, 74, 75, 78, 165, 223, 108, 62, 255, 129, 254, 92, 228, 60, 63, 204, 110, 148, 228, 72, 181, 102, 114, 228, 195, 204, 6, 45, 215, 181, 232, 134, 24, 31, 16, 114, 113, 84, 180, 154, 29, 47, 167, 67, 74, 188, 196, 117, 121, 188, 39, 192, 209, 252, 42, 127, 114, 35, 148, 153, 31, 186, 154, 142, 156, 212, 136, 138, 15, 255, 148, 223, 201, 112, 212, 125, 101, 32, 190, 143, 233 } });
        }
    }
}
