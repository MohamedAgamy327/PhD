using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class QuestionAverageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Q10",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Q12",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Q13",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Q14",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Q15",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Q16",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Q17",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Q8",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Q9",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 227, 120, 162, 70, 86, 219, 20, 137, 236, 67, 134, 40, 180, 7, 250, 58, 18, 29, 104, 125, 189, 194, 178, 206, 175, 246, 23, 195, 94, 54, 89, 161, 22, 226, 24, 126, 63, 55, 214, 239, 255, 117, 237, 2, 75, 231, 219, 226, 54, 70, 159, 80, 25, 205, 106, 82, 161, 93, 27, 68, 254, 127, 60, 93 }, new byte[] { 124, 18, 45, 51, 80, 123, 165, 13, 107, 155, 114, 131, 119, 53, 42, 157, 223, 143, 168, 158, 195, 117, 34, 118, 24, 156, 46, 49, 154, 93, 125, 31, 61, 177, 59, 54, 3, 192, 110, 64, 8, 18, 142, 201, 103, 88, 57, 3, 197, 175, 229, 129, 44, 186, 200, 227, 252, 105, 34, 190, 148, 207, 71, 99, 10, 226, 169, 47, 84, 32, 143, 253, 179, 9, 250, 207, 204, 28, 255, 104, 28, 180, 141, 89, 119, 95, 124, 76, 168, 58, 222, 58, 111, 160, 50, 229, 221, 109, 175, 164, 62, 90, 210, 191, 70, 93, 109, 6, 237, 211, 148, 106, 125, 205, 40, 202, 58, 247, 71, 138, 167, 81, 153, 16, 161, 122, 242, 124 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Q10",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Q12",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Q13",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Q14",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Q15",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Q16",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Q17",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Q8",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Q9",
                table: "Researchs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 253, 74, 170, 8, 199, 147, 50, 177, 39, 227, 166, 26, 92, 228, 75, 91, 33, 96, 30, 76, 46, 201, 209, 213, 81, 125, 116, 226, 34, 51, 238, 73, 86, 138, 82, 89, 5, 60, 162, 14, 98, 131, 206, 170, 213, 90, 243, 84, 32, 245, 233, 95, 200, 112, 37, 111, 172, 79, 247, 228, 241, 113, 109, 33 }, new byte[] { 40, 248, 93, 107, 58, 95, 153, 113, 127, 213, 159, 144, 105, 203, 99, 183, 206, 149, 167, 12, 67, 10, 221, 204, 56, 189, 13, 129, 144, 203, 160, 188, 199, 253, 184, 227, 128, 117, 8, 217, 121, 118, 58, 76, 119, 117, 148, 8, 112, 235, 183, 48, 189, 157, 24, 223, 244, 155, 91, 248, 18, 30, 48, 63, 253, 248, 41, 83, 193, 54, 206, 15, 152, 167, 189, 198, 13, 18, 33, 141, 35, 149, 199, 170, 241, 2, 20, 240, 171, 96, 226, 106, 20, 133, 41, 159, 146, 239, 250, 0, 139, 167, 77, 67, 182, 135, 213, 146, 242, 41, 174, 65, 4, 174, 206, 18, 66, 62, 112, 42, 53, 195, 101, 82, 245, 229, 57, 249 } });
        }
    }
}
