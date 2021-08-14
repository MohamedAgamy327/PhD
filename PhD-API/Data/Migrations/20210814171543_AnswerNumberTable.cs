using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AnswerNumberTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerNumbers_Researchs_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 53, 39, 146, 238, 213, 55, 107, 225, 125, 127, 245, 199, 146, 144, 200, 252, 218, 95, 17, 106, 183, 191, 212, 171, 1, 56, 73, 176, 33, 205, 91, 239, 152, 59, 87, 174, 145, 129, 167, 118, 43, 129, 236, 248, 30, 43, 168, 214, 106, 225, 14, 66, 249, 68, 46, 228, 90, 48, 98, 188, 231, 216, 178, 192 }, new byte[] { 133, 71, 183, 35, 146, 156, 69, 209, 67, 162, 158, 118, 161, 12, 163, 132, 152, 55, 150, 173, 132, 16, 194, 143, 240, 217, 56, 84, 99, 196, 75, 86, 255, 96, 103, 191, 15, 235, 147, 118, 8, 34, 1, 171, 129, 132, 213, 131, 154, 213, 127, 109, 249, 234, 33, 125, 30, 132, 201, 93, 37, 115, 82, 9, 167, 156, 192, 14, 245, 244, 91, 194, 93, 164, 217, 233, 144, 144, 100, 221, 202, 143, 86, 159, 32, 140, 18, 162, 214, 170, 225, 61, 118, 252, 78, 40, 231, 53, 254, 228, 133, 5, 122, 85, 186, 168, 154, 166, 149, 80, 217, 211, 233, 176, 79, 184, 48, 162, 244, 196, 176, 152, 130, 35, 79, 207, 91, 92 } });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerNumbers_ResearchId",
                table: "AnswerNumbers",
                column: "ResearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerNumbers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 72, 51, 202, 46, 158, 246, 53, 15, 88, 156, 222, 129, 84, 29, 249, 219, 118, 79, 171, 29, 195, 78, 210, 198, 161, 45, 38, 179, 178, 4, 7, 228, 250, 241, 7, 196, 173, 61, 172, 48, 119, 80, 234, 230, 31, 160, 170, 97, 10, 85, 87, 209, 242, 249, 100, 93, 220, 34, 149, 227, 20, 0, 117, 198 }, new byte[] { 240, 163, 20, 189, 141, 66, 145, 6, 73, 157, 47, 61, 140, 116, 78, 142, 49, 116, 252, 247, 119, 183, 116, 92, 154, 9, 144, 67, 144, 63, 247, 206, 43, 36, 145, 36, 106, 213, 155, 142, 52, 178, 131, 27, 123, 215, 187, 74, 56, 12, 192, 178, 103, 49, 231, 194, 144, 38, 188, 25, 253, 141, 237, 152, 97, 198, 155, 42, 240, 174, 121, 26, 146, 227, 107, 150, 184, 117, 107, 88, 248, 143, 188, 108, 27, 4, 84, 214, 30, 10, 190, 173, 184, 105, 33, 7, 85, 148, 143, 20, 226, 207, 131, 179, 69, 5, 205, 93, 253, 174, 117, 7, 224, 141, 165, 170, 170, 142, 216, 194, 11, 228, 248, 162, 20, 64, 138, 108 } });
        }
    }
}
