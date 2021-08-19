using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ResearchQuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResearchsQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ResearchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchsQuestions", x => new { x.QuestionId, x.ResearchId });
                    table.ForeignKey(
                        name: "FK_ResearchsQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchsQuestions_Researchs_ResearchId",
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
                values: new object[] { new byte[] { 33, 242, 129, 61, 201, 183, 89, 76, 212, 87, 199, 87, 245, 146, 82, 221, 27, 55, 133, 245, 73, 113, 218, 247, 192, 219, 240, 120, 115, 108, 72, 37, 59, 205, 51, 248, 11, 214, 161, 152, 246, 15, 191, 194, 248, 165, 181, 197, 114, 163, 20, 135, 41, 22, 41, 152, 209, 55, 53, 221, 161, 12, 102, 176 }, new byte[] { 87, 160, 253, 130, 169, 64, 20, 95, 56, 63, 134, 20, 88, 171, 163, 215, 245, 80, 76, 83, 102, 71, 69, 31, 94, 255, 162, 110, 0, 195, 180, 132, 195, 177, 149, 79, 198, 102, 170, 207, 40, 97, 188, 42, 112, 124, 226, 128, 74, 164, 229, 150, 146, 124, 83, 38, 87, 220, 76, 247, 146, 175, 247, 178, 42, 191, 176, 0, 22, 231, 197, 177, 44, 50, 92, 17, 117, 18, 203, 100, 115, 186, 148, 142, 39, 208, 153, 224, 251, 13, 77, 127, 210, 65, 47, 183, 143, 223, 56, 166, 202, 87, 61, 31, 56, 46, 84, 45, 69, 141, 82, 109, 90, 210, 117, 158, 9, 198, 62, 244, 64, 120, 246, 54, 178, 165, 160, 47 } });

            migrationBuilder.CreateIndex(
                name: "IX_ResearchsQuestions_ResearchId",
                table: "ResearchsQuestions",
                column: "ResearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearchsQuestions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 8, 104, 137, 45, 8, 185, 192, 92, 196, 40, 87, 248, 230, 50, 234, 176, 134, 107, 62, 52, 54, 246, 218, 222, 2, 23, 41, 100, 157, 7, 140, 49, 88, 121, 71, 102, 8, 69, 37, 96, 135, 90, 166, 60, 186, 239, 106, 224, 51, 51, 65, 123, 22, 31, 58, 164, 129, 67, 163, 67, 18, 179, 1, 78 }, new byte[] { 178, 213, 35, 101, 165, 61, 250, 233, 85, 140, 245, 141, 107, 250, 228, 59, 151, 58, 65, 212, 100, 185, 208, 187, 102, 23, 41, 252, 28, 241, 98, 151, 76, 65, 208, 214, 93, 207, 100, 26, 163, 38, 157, 79, 138, 164, 57, 228, 164, 232, 122, 142, 169, 49, 95, 250, 82, 37, 207, 31, 78, 140, 18, 81, 57, 240, 13, 147, 107, 165, 114, 174, 156, 48, 55, 181, 102, 174, 182, 54, 124, 25, 218, 212, 145, 170, 19, 161, 119, 217, 32, 20, 189, 207, 204, 57, 59, 191, 142, 236, 89, 140, 237, 35, 119, 141, 117, 112, 64, 80, 131, 17, 78, 144, 189, 203, 108, 247, 216, 124, 128, 147, 157, 249, 19, 90, 120, 215 } });
        }
    }
}
