using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FinalResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Final",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "First",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Second",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Third",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 209, 240, 91, 94, 6, 28, 26, 127, 251, 159, 183, 71, 207, 205, 104, 108, 244, 160, 26, 118, 141, 215, 18, 77, 46, 71, 23, 59, 168, 4, 28, 152, 155, 164, 225, 207, 217, 99, 219, 202, 147, 54, 165, 75, 37, 86, 194, 156, 199, 18, 72, 47, 5, 29, 164, 77, 113, 247, 237, 26, 136, 40, 179, 233 }, new byte[] { 40, 108, 44, 26, 153, 102, 99, 21, 229, 3, 138, 5, 30, 163, 143, 237, 58, 128, 133, 164, 49, 172, 4, 248, 84, 247, 247, 57, 147, 70, 120, 255, 237, 64, 222, 137, 89, 230, 130, 129, 40, 130, 1, 151, 191, 109, 244, 51, 160, 225, 104, 237, 55, 167, 15, 25, 26, 130, 122, 80, 153, 108, 10, 78, 174, 200, 207, 154, 50, 169, 138, 247, 87, 22, 195, 71, 59, 216, 141, 211, 181, 194, 40, 185, 39, 15, 239, 201, 252, 19, 184, 140, 75, 197, 254, 83, 179, 154, 31, 113, 211, 155, 141, 177, 173, 107, 193, 37, 122, 159, 229, 236, 16, 123, 35, 70, 91, 232, 64, 79, 65, 174, 107, 138, 47, 131, 100, 235 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Final",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "First",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Second",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Third",
                table: "Researchs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 227, 120, 162, 70, 86, 219, 20, 137, 236, 67, 134, 40, 180, 7, 250, 58, 18, 29, 104, 125, 189, 194, 178, 206, 175, 246, 23, 195, 94, 54, 89, 161, 22, 226, 24, 126, 63, 55, 214, 239, 255, 117, 237, 2, 75, 231, 219, 226, 54, 70, 159, 80, 25, 205, 106, 82, 161, 93, 27, 68, 254, 127, 60, 93 }, new byte[] { 124, 18, 45, 51, 80, 123, 165, 13, 107, 155, 114, 131, 119, 53, 42, 157, 223, 143, 168, 158, 195, 117, 34, 118, 24, 156, 46, 49, 154, 93, 125, 31, 61, 177, 59, 54, 3, 192, 110, 64, 8, 18, 142, 201, 103, 88, 57, 3, 197, 175, 229, 129, 44, 186, 200, 227, 252, 105, 34, 190, 148, 207, 71, 99, 10, 226, 169, 47, 84, 32, 143, 253, 179, 9, 250, 207, 204, 28, 255, 104, 28, 180, 141, 89, 119, 95, 124, 76, 168, 58, 222, 58, 111, 160, 50, 229, 221, 109, 175, 164, 62, 90, 210, 191, 70, 93, 109, 6, 237, 211, 148, 106, 125, 205, 40, 202, 58, 247, 71, 138, 167, 81, 153, 16, 161, 122, 242, 124 } });
        }
    }
}
