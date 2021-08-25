using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ResearchQuestionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswersCount",
                table: "Researchs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanEdit",
                table: "Researchs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 188, 34, 234, 239, 78, 235, 191, 103, 103, 165, 248, 34, 62, 205, 155, 41, 205, 182, 187, 101, 42, 33, 147, 209, 167, 71, 66, 174, 218, 148, 192, 237, 36, 222, 67, 35, 174, 156, 237, 23, 227, 11, 201, 130, 237, 202, 0, 193, 200, 3, 201, 116, 42, 5, 102, 226, 80, 25, 99, 69, 84, 234, 220, 30 }, new byte[] { 184, 77, 193, 102, 205, 209, 8, 109, 3, 46, 135, 244, 217, 74, 160, 184, 153, 83, 58, 18, 252, 208, 232, 195, 205, 77, 205, 58, 99, 204, 241, 134, 237, 20, 12, 64, 68, 65, 95, 87, 49, 13, 249, 177, 26, 57, 103, 183, 229, 79, 30, 96, 109, 113, 206, 251, 146, 149, 119, 255, 111, 169, 150, 229, 4, 147, 21, 142, 20, 34, 182, 235, 89, 153, 214, 35, 134, 127, 17, 211, 253, 179, 109, 138, 111, 179, 155, 59, 104, 201, 247, 60, 211, 95, 24, 151, 197, 250, 56, 4, 118, 118, 124, 147, 99, 174, 161, 113, 205, 229, 134, 156, 245, 200, 2, 181, 198, 42, 238, 158, 60, 138, 31, 243, 165, 141, 237, 116 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswersCount",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "CanEdit",
                table: "Researchs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 33, 242, 129, 61, 201, 183, 89, 76, 212, 87, 199, 87, 245, 146, 82, 221, 27, 55, 133, 245, 73, 113, 218, 247, 192, 219, 240, 120, 115, 108, 72, 37, 59, 205, 51, 248, 11, 214, 161, 152, 246, 15, 191, 194, 248, 165, 181, 197, 114, 163, 20, 135, 41, 22, 41, 152, 209, 55, 53, 221, 161, 12, 102, 176 }, new byte[] { 87, 160, 253, 130, 169, 64, 20, 95, 56, 63, 134, 20, 88, 171, 163, 215, 245, 80, 76, 83, 102, 71, 69, 31, 94, 255, 162, 110, 0, 195, 180, 132, 195, 177, 149, 79, 198, 102, 170, 207, 40, 97, 188, 42, 112, 124, 226, 128, 74, 164, 229, 150, 146, 124, 83, 38, 87, 220, 76, 247, 146, 175, 247, 178, 42, 191, 176, 0, 22, 231, 197, 177, 44, 50, 92, 17, 117, 18, 203, 100, 115, 186, 148, 142, 39, 208, 153, 224, 251, 13, 77, 127, 210, 65, 47, 183, 143, 223, 56, 166, 202, 87, 61, 31, 56, 46, 84, 45, 69, 141, 82, 109, 90, 210, 117, 158, 9, 198, 62, 244, 64, 120, 246, 54, 178, 165, 160, 47 } });
        }
    }
}
