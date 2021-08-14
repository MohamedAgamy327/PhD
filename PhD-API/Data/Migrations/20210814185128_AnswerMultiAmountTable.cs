using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AnswerMultiAmountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerMultiAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerMultiAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerMultiAmounts_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerMultiAmounts_Researchs_ResearchId",
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
                values: new object[] { new byte[] { 191, 214, 228, 32, 176, 2, 155, 162, 83, 89, 94, 52, 243, 216, 32, 174, 16, 80, 181, 79, 39, 163, 7, 180, 226, 61, 43, 72, 60, 229, 167, 196, 158, 123, 204, 42, 244, 123, 5, 229, 10, 38, 240, 2, 13, 247, 255, 211, 10, 254, 14, 26, 30, 206, 144, 174, 247, 230, 240, 173, 52, 7, 73, 71 }, new byte[] { 15, 4, 114, 190, 223, 128, 45, 151, 56, 136, 51, 180, 103, 81, 162, 251, 179, 162, 128, 101, 248, 196, 104, 85, 107, 96, 5, 38, 96, 87, 166, 35, 68, 37, 211, 182, 53, 24, 141, 215, 181, 57, 88, 164, 71, 222, 69, 27, 63, 238, 246, 52, 210, 190, 82, 32, 81, 98, 165, 95, 29, 84, 51, 23, 8, 55, 195, 56, 89, 159, 255, 205, 74, 15, 109, 138, 138, 107, 115, 77, 56, 89, 245, 77, 19, 52, 149, 134, 163, 212, 211, 11, 151, 140, 57, 243, 10, 51, 94, 252, 211, 142, 80, 180, 29, 28, 134, 70, 147, 218, 233, 32, 102, 225, 155, 228, 10, 38, 151, 48, 219, 126, 118, 26, 126, 31, 62, 121 } });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerMultiAmounts_AnswerId",
                table: "AnswerMultiAmounts",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerMultiAmounts_ResearchId",
                table: "AnswerMultiAmounts",
                column: "ResearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerMultiAmounts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 53, 39, 146, 238, 213, 55, 107, 225, 125, 127, 245, 199, 146, 144, 200, 252, 218, 95, 17, 106, 183, 191, 212, 171, 1, 56, 73, 176, 33, 205, 91, 239, 152, 59, 87, 174, 145, 129, 167, 118, 43, 129, 236, 248, 30, 43, 168, 214, 106, 225, 14, 66, 249, 68, 46, 228, 90, 48, 98, 188, 231, 216, 178, 192 }, new byte[] { 133, 71, 183, 35, 146, 156, 69, 209, 67, 162, 158, 118, 161, 12, 163, 132, 152, 55, 150, 173, 132, 16, 194, 143, 240, 217, 56, 84, 99, 196, 75, 86, 255, 96, 103, 191, 15, 235, 147, 118, 8, 34, 1, 171, 129, 132, 213, 131, 154, 213, 127, 109, 249, 234, 33, 125, 30, 132, 201, 93, 37, 115, 82, 9, 167, 156, 192, 14, 245, 244, 91, 194, 93, 164, 217, 233, 144, 144, 100, 221, 202, 143, 86, 159, 32, 140, 18, 162, 214, 170, 225, 61, 118, 252, 78, 40, 231, 53, 254, 228, 133, 5, 122, 85, 186, 168, 154, 166, 149, 80, 217, 211, 233, 176, 79, 184, 48, 162, 244, 196, 176, 152, 130, 35, 79, 207, 91, 92 } });
        }
    }
}
