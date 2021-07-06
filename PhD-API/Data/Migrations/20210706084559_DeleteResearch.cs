using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DeleteResearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Researchs",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 8, 119, 166, 127, 182, 126, 75, 207, 75, 33, 28, 202, 152, 170, 255, 193, 235, 141, 118, 144, 64, 180, 81, 241, 64, 182, 9, 73, 22, 39, 156, 100, 223, 205, 206, 254, 1, 93, 105, 43, 24, 243, 214, 172, 66, 253, 97, 132, 198, 15, 193, 167, 122, 37, 232, 13, 131, 90, 98, 218, 4, 253, 125, 23 }, new byte[] { 116, 225, 88, 171, 80, 26, 78, 121, 236, 47, 236, 112, 158, 205, 213, 38, 152, 36, 93, 132, 30, 209, 192, 74, 148, 159, 33, 156, 26, 14, 85, 157, 42, 12, 54, 30, 76, 234, 55, 116, 144, 30, 28, 137, 74, 204, 125, 10, 119, 68, 19, 161, 120, 64, 55, 26, 119, 225, 31, 216, 162, 21, 195, 35, 114, 107, 177, 150, 122, 35, 134, 224, 114, 220, 158, 170, 145, 33, 123, 41, 142, 218, 99, 17, 132, 234, 187, 17, 217, 160, 35, 43, 211, 33, 211, 127, 214, 207, 81, 61, 209, 12, 249, 240, 57, 49, 123, 83, 135, 33, 199, 53, 130, 31, 132, 223, 195, 156, 90, 155, 201, 212, 8, 231, 195, 49, 90, 232 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Researchs");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Researchs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 144, 227, 199, 146, 119, 89, 134, 200, 75, 202, 216, 66, 106, 170, 194, 209, 165, 213, 209, 235, 88, 200, 161, 105, 229, 45, 117, 95, 224, 157, 193, 167, 186, 218, 156, 22, 213, 105, 92, 222, 60, 140, 254, 180, 126, 179, 136, 33, 64, 178, 221, 202, 180, 64, 12, 129, 52, 192, 117, 94, 151, 238, 190, 94 }, new byte[] { 35, 39, 137, 198, 153, 11, 18, 117, 185, 0, 27, 23, 205, 90, 22, 181, 29, 36, 89, 17, 212, 49, 240, 24, 0, 220, 105, 86, 127, 189, 79, 6, 84, 159, 11, 226, 82, 120, 57, 106, 65, 59, 8, 25, 12, 31, 116, 46, 210, 128, 43, 201, 227, 171, 253, 16, 19, 139, 255, 22, 114, 34, 152, 62, 212, 61, 135, 162, 100, 35, 64, 103, 155, 217, 179, 52, 230, 251, 236, 28, 155, 247, 47, 223, 126, 154, 29, 91, 155, 243, 200, 5, 104, 45, 46, 238, 143, 48, 198, 147, 147, 75, 244, 126, 230, 85, 60, 57, 88, 238, 52, 150, 108, 173, 213, 71, 118, 174, 25, 94, 236, 139, 12, 97, 159, 220, 233, 63 } });
        }
    }
}
