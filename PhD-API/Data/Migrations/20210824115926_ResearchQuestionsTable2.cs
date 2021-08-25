using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ResearchQuestionsTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CanEdit",
                table: "Researchs",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 243, 214, 11, 176, 102, 198, 23, 34, 174, 165, 110, 76, 152, 234, 164, 95, 244, 59, 37, 197, 29, 43, 182, 65, 243, 113, 148, 55, 59, 0, 24, 248, 191, 112, 211, 80, 255, 221, 166, 12, 108, 78, 15, 176, 197, 24, 130, 206, 192, 81, 29, 6, 119, 238, 238, 205, 98, 111, 209, 182, 105, 26, 185 }, new byte[] { 2, 74, 183, 244, 119, 164, 239, 84, 13, 119, 32, 245, 31, 251, 61, 206, 146, 161, 21, 141, 248, 176, 97, 20, 171, 153, 187, 24, 37, 225, 91, 120, 147, 166, 148, 80, 7, 45, 31, 109, 65, 162, 18, 231, 156, 51, 15, 248, 95, 48, 35, 9, 133, 87, 169, 54, 58, 129, 190, 151, 158, 237, 46, 59, 82, 247, 192, 222, 78, 105, 50, 127, 106, 209, 122, 148, 12, 15, 3, 239, 140, 182, 64, 165, 86, 146, 192, 195, 29, 45, 118, 233, 230, 116, 248, 53, 225, 60, 228, 62, 154, 225, 232, 118, 119, 150, 236, 119, 119, 23, 69, 146, 47, 69, 151, 118, 86, 219, 243, 13, 146, 111, 231, 248, 33, 86, 224, 82 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CanEdit",
                table: "Researchs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 188, 34, 234, 239, 78, 235, 191, 103, 103, 165, 248, 34, 62, 205, 155, 41, 205, 182, 187, 101, 42, 33, 147, 209, 167, 71, 66, 174, 218, 148, 192, 237, 36, 222, 67, 35, 174, 156, 237, 23, 227, 11, 201, 130, 237, 202, 0, 193, 200, 3, 201, 116, 42, 5, 102, 226, 80, 25, 99, 69, 84, 234, 220, 30 }, new byte[] { 184, 77, 193, 102, 205, 209, 8, 109, 3, 46, 135, 244, 217, 74, 160, 184, 153, 83, 58, 18, 252, 208, 232, 195, 205, 77, 205, 58, 99, 204, 241, 134, 237, 20, 12, 64, 68, 65, 95, 87, 49, 13, 249, 177, 26, 57, 103, 183, 229, 79, 30, 96, 109, 113, 206, 251, 146, 149, 119, 255, 111, 169, 150, 229, 4, 147, 21, 142, 20, 34, 182, 235, 89, 153, 214, 35, 134, 127, 17, 211, 253, 179, 109, 138, 111, 179, 155, 59, 104, 201, 247, 60, 211, 95, 24, 151, 197, 250, 56, 4, 118, 118, 124, 147, 99, 174, 161, 113, 205, 229, 134, 156, 245, 200, 2, 181, 198, 42, 238, 158, 60, 138, 31, 243, 165, 141, 237, 116 } });
        }
    }
}
