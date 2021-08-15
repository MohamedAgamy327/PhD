using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AnswerMultiPercentageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerMultiPercentages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: true),
                    Number1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Number2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Radio = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerMultiPercentages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerMultiPercentages_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerMultiPercentages_Researchs_ResearchId",
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
                values: new object[] { new byte[] { 90, 183, 205, 32, 180, 51, 219, 241, 127, 45, 179, 58, 50, 84, 54, 119, 225, 56, 123, 184, 109, 57, 21, 22, 77, 18, 135, 229, 182, 237, 84, 189, 251, 225, 208, 231, 42, 8, 148, 183, 28, 89, 193, 128, 158, 91, 113, 82, 130, 144, 100, 45, 45, 107, 248, 220, 86, 168, 162, 243, 243, 127, 205, 53 }, new byte[] { 86, 76, 198, 226, 210, 105, 174, 220, 22, 57, 230, 39, 214, 234, 219, 232, 131, 191, 231, 147, 63, 97, 146, 205, 168, 89, 245, 128, 162, 89, 36, 146, 49, 205, 252, 40, 27, 28, 212, 147, 44, 81, 146, 100, 248, 154, 107, 248, 27, 103, 167, 244, 214, 215, 207, 24, 134, 45, 107, 37, 228, 186, 149, 126, 30, 68, 22, 41, 141, 26, 107, 216, 87, 98, 169, 7, 135, 181, 224, 117, 93, 17, 94, 13, 44, 100, 92, 188, 31, 229, 49, 242, 147, 176, 51, 106, 12, 34, 194, 113, 179, 32, 217, 201, 182, 81, 73, 223, 79, 70, 139, 115, 172, 230, 236, 219, 17, 75, 245, 254, 103, 40, 49, 68, 5, 200, 161, 226 } });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerMultiPercentages_AnswerId",
                table: "AnswerMultiPercentages",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerMultiPercentages_ResearchId",
                table: "AnswerMultiPercentages",
                column: "ResearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerMultiPercentages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 191, 214, 228, 32, 176, 2, 155, 162, 83, 89, 94, 52, 243, 216, 32, 174, 16, 80, 181, 79, 39, 163, 7, 180, 226, 61, 43, 72, 60, 229, 167, 196, 158, 123, 204, 42, 244, 123, 5, 229, 10, 38, 240, 2, 13, 247, 255, 211, 10, 254, 14, 26, 30, 206, 144, 174, 247, 230, 240, 173, 52, 7, 73, 71 }, new byte[] { 15, 4, 114, 190, 223, 128, 45, 151, 56, 136, 51, 180, 103, 81, 162, 251, 179, 162, 128, 101, 248, 196, 104, 85, 107, 96, 5, 38, 96, 87, 166, 35, 68, 37, 211, 182, 53, 24, 141, 215, 181, 57, 88, 164, 71, 222, 69, 27, 63, 238, 246, 52, 210, 190, 82, 32, 81, 98, 165, 95, 29, 84, 51, 23, 8, 55, 195, 56, 89, 159, 255, 205, 74, 15, 109, 138, 138, 107, 115, 77, 56, 89, 245, 77, 19, 52, 149, 134, 163, 212, 211, 11, 151, 140, 57, 243, 10, 51, 94, 252, 211, 142, 80, 180, 29, 28, 134, 70, 147, 218, 233, 32, 102, 225, 155, 228, 10, 38, 151, 48, 219, 126, 118, 26, 126, 31, 62, 121 } });
        }
    }
}
