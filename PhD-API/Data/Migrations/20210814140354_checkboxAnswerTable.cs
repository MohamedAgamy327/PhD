using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class checkboxAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerCheckboxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: true),
                    Checked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerCheckboxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerCheckboxs_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerCheckboxs_Researchs_ResearchId",
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
                values: new object[] { new byte[] { 72, 51, 202, 46, 158, 246, 53, 15, 88, 156, 222, 129, 84, 29, 249, 219, 118, 79, 171, 29, 195, 78, 210, 198, 161, 45, 38, 179, 178, 4, 7, 228, 250, 241, 7, 196, 173, 61, 172, 48, 119, 80, 234, 230, 31, 160, 170, 97, 10, 85, 87, 209, 242, 249, 100, 93, 220, 34, 149, 227, 20, 0, 117, 198 }, new byte[] { 240, 163, 20, 189, 141, 66, 145, 6, 73, 157, 47, 61, 140, 116, 78, 142, 49, 116, 252, 247, 119, 183, 116, 92, 154, 9, 144, 67, 144, 63, 247, 206, 43, 36, 145, 36, 106, 213, 155, 142, 52, 178, 131, 27, 123, 215, 187, 74, 56, 12, 192, 178, 103, 49, 231, 194, 144, 38, 188, 25, 253, 141, 237, 152, 97, 198, 155, 42, 240, 174, 121, 26, 146, 227, 107, 150, 184, 117, 107, 88, 248, 143, 188, 108, 27, 4, 84, 214, 30, 10, 190, 173, 184, 105, 33, 7, 85, 148, 143, 20, 226, 207, 131, 179, 69, 5, 205, 93, 253, 174, 117, 7, 224, 141, 165, 170, 170, 142, 216, 194, 11, 228, 248, 162, 20, 64, 138, 108 } });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerCheckboxs_AnswerId",
                table: "AnswerCheckboxs",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerCheckboxs_ResearchId",
                table: "AnswerCheckboxs",
                column: "ResearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerCheckboxs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 32, 204, 87, 218, 225, 29, 188, 103, 48, 15, 228, 1, 154, 196, 120, 105, 74, 40, 153, 196, 70, 32, 121, 34, 133, 126, 194, 72, 101, 95, 206, 241, 101, 126, 193, 166, 182, 42, 143, 83, 51, 113, 192, 95, 82, 176, 122, 206, 45, 120, 110, 106, 94, 28, 59, 178, 209, 174, 219, 169, 148, 192, 132, 167 }, new byte[] { 250, 223, 4, 253, 203, 114, 219, 31, 93, 53, 102, 87, 242, 58, 49, 131, 226, 116, 183, 47, 31, 185, 87, 45, 165, 31, 247, 142, 21, 2, 76, 60, 249, 31, 123, 15, 38, 64, 184, 149, 35, 159, 210, 139, 45, 174, 183, 242, 79, 216, 140, 131, 254, 22, 183, 94, 51, 124, 189, 177, 71, 252, 168, 8, 244, 108, 11, 189, 12, 216, 86, 173, 154, 245, 110, 24, 51, 119, 211, 217, 203, 104, 49, 114, 180, 119, 191, 86, 69, 57, 102, 250, 152, 195, 134, 139, 9, 202, 1, 165, 154, 26, 135, 248, 137, 55, 168, 218, 68, 218, 224, 64, 101, 239, 163, 139, 180, 221, 194, 85, 233, 33, 128, 157, 126, 100, 31, 112 } });
        }
    }
}
