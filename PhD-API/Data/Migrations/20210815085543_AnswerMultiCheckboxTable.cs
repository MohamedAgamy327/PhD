using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AnswerMultiCheckboxTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerMultiCheckboxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: true),
                    Checked1 = table.Column<bool>(type: "bit", nullable: false),
                    Checked2 = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Radio = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerMultiCheckboxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerMultiCheckboxs_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerMultiCheckboxs_Researchs_ResearchId",
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
                values: new object[] { new byte[] { 41, 162, 35, 242, 72, 66, 143, 144, 63, 15, 190, 185, 37, 68, 206, 131, 54, 87, 209, 227, 220, 111, 250, 110, 89, 139, 186, 223, 114, 149, 164, 131, 193, 99, 155, 181, 68, 31, 176, 205, 66, 52, 208, 68, 146, 232, 71, 144, 52, 102, 190, 85, 34, 31, 43, 204, 43, 136, 112, 158, 248, 223, 72, 160 }, new byte[] { 187, 158, 69, 168, 66, 116, 3, 16, 166, 192, 27, 90, 6, 30, 149, 22, 224, 56, 174, 18, 195, 94, 66, 143, 80, 219, 187, 217, 188, 161, 144, 168, 88, 176, 146, 183, 151, 165, 144, 37, 232, 77, 209, 26, 252, 48, 21, 8, 50, 59, 60, 195, 200, 84, 229, 135, 108, 191, 204, 193, 189, 159, 139, 214, 182, 139, 200, 251, 129, 153, 52, 215, 218, 238, 4, 22, 142, 68, 144, 44, 169, 84, 54, 249, 180, 185, 28, 59, 97, 164, 205, 195, 202, 129, 31, 31, 99, 69, 81, 197, 79, 33, 211, 160, 82, 78, 71, 165, 158, 223, 138, 81, 81, 48, 239, 233, 250, 150, 228, 119, 244, 113, 102, 116, 62, 231, 150, 52 } });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerMultiCheckboxs_AnswerId",
                table: "AnswerMultiCheckboxs",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerMultiCheckboxs_ResearchId",
                table: "AnswerMultiCheckboxs",
                column: "ResearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerMultiCheckboxs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 90, 183, 205, 32, 180, 51, 219, 241, 127, 45, 179, 58, 50, 84, 54, 119, 225, 56, 123, 184, 109, 57, 21, 22, 77, 18, 135, 229, 182, 237, 84, 189, 251, 225, 208, 231, 42, 8, 148, 183, 28, 89, 193, 128, 158, 91, 113, 82, 130, 144, 100, 45, 45, 107, 248, 220, 86, 168, 162, 243, 243, 127, 205, 53 }, new byte[] { 86, 76, 198, 226, 210, 105, 174, 220, 22, 57, 230, 39, 214, 234, 219, 232, 131, 191, 231, 147, 63, 97, 146, 205, 168, 89, 245, 128, 162, 89, 36, 146, 49, 205, 252, 40, 27, 28, 212, 147, 44, 81, 146, 100, 248, 154, 107, 248, 27, 103, 167, 244, 214, 215, 207, 24, 134, 45, 107, 37, 228, 186, 149, 126, 30, 68, 22, 41, 141, 26, 107, 216, 87, 98, 169, 7, 135, 181, 224, 117, 93, 17, 94, 13, 44, 100, 92, 188, 31, 229, 49, 242, 147, 176, 51, 106, 12, 34, 194, 113, 179, 32, 217, 201, 182, 81, 73, 223, 79, 70, 139, 115, 172, 230, 236, 219, 17, 75, 245, 254, 103, 40, 49, 68, 5, 200, 161, 226 } });
        }
    }
}
