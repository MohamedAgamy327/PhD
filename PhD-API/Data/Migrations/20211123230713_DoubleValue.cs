using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DoubleValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Third",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Second",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Q9",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Q8",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Q17",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Q16",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Q15",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Q14",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Q13",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Q12",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Q10",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "First",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Final",
                table: "Researchs",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Number2",
                table: "AnswerMultiPercentages",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Number1",
                table: "AnswerMultiPercentages",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "AnswerMultiAmounts",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 144, 0, 34, 227, 174, 196, 154, 71, 241, 227, 101, 206, 217, 89, 192, 193, 235, 69, 69, 89, 218, 83, 202, 238, 6, 28, 165, 248, 144, 58, 33, 7, 23, 235, 40, 46, 212, 84, 48, 225, 87, 148, 28, 226, 160, 135, 174, 227, 253, 32, 100, 253, 40, 163, 114, 40, 74, 120, 31, 55, 54, 252, 212, 61 }, new byte[] { 27, 75, 51, 192, 142, 19, 67, 20, 185, 135, 77, 210, 197, 184, 90, 215, 4, 0, 55, 169, 133, 31, 172, 53, 8, 149, 183, 130, 64, 126, 191, 121, 128, 222, 235, 141, 112, 126, 150, 45, 213, 61, 54, 11, 194, 85, 123, 50, 253, 200, 168, 196, 124, 10, 54, 60, 53, 67, 137, 77, 251, 212, 153, 89, 13, 113, 254, 238, 156, 132, 88, 7, 4, 222, 208, 184, 149, 189, 89, 8, 243, 22, 202, 121, 25, 109, 235, 114, 217, 109, 200, 199, 95, 4, 155, 90, 192, 70, 15, 34, 162, 149, 82, 15, 141, 12, 20, 178, 187, 83, 48, 117, 222, 110, 74, 228, 216, 56, 18, 48, 170, 73, 35, 75, 137, 218, 212, 148 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Third",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Second",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Q9",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Q8",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Q17",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Q16",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Q15",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Q14",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Q13",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Q12",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Q10",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "First",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Final",
                table: "Researchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Number2",
                table: "AnswerMultiPercentages",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Number1",
                table: "AnswerMultiPercentages",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "AnswerMultiAmounts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 203, 43, 104, 57, 165, 113, 83, 185, 136, 144, 249, 24, 217, 74, 163, 240, 148, 27, 86, 156, 65, 121, 3, 236, 125, 126, 152, 214, 55, 93, 212, 209, 198, 168, 97, 111, 222, 219, 30, 146, 10, 129, 34, 75, 30, 19, 220, 115, 102, 217, 207, 140, 203, 92, 65, 168, 146, 103, 166, 88, 140, 194, 64, 234 }, new byte[] { 110, 81, 228, 124, 173, 118, 136, 178, 225, 45, 133, 172, 168, 53, 211, 10, 53, 101, 96, 219, 98, 85, 165, 142, 99, 1, 133, 118, 183, 129, 162, 8, 10, 53, 76, 142, 252, 73, 52, 227, 211, 238, 205, 205, 23, 155, 107, 235, 75, 76, 59, 133, 223, 146, 71, 189, 142, 0, 197, 92, 154, 14, 106, 91, 245, 162, 49, 112, 34, 249, 70, 237, 123, 31, 33, 134, 47, 94, 5, 217, 70, 205, 29, 150, 94, 61, 77, 223, 68, 167, 210, 28, 122, 39, 166, 87, 13, 134, 40, 42, 49, 174, 4, 23, 176, 161, 169, 3, 71, 23, 23, 191, 125, 21, 57, 234, 98, 57, 254, 175, 149, 166, 140, 42, 144, 161, 181, 238 } });
        }
    }
}
