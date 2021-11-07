using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ResearchUpdatesDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Researchs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "Researchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Program",
                table: "Researchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 158, 194, 177, 64, 165, 75, 80, 8, 88, 89, 13, 64, 137, 24, 114, 246, 230, 52, 173, 206, 72, 122, 193, 227, 162, 91, 82, 59, 169, 183, 114, 85, 239, 178, 163, 84, 161, 60, 166, 25, 44, 187, 9, 138, 150, 192, 15, 179, 114, 248, 135, 213, 71, 147, 88, 203, 6, 43, 76, 3, 11, 99, 73, 15 }, new byte[] { 32, 0, 196, 232, 5, 232, 216, 160, 142, 204, 125, 209, 204, 255, 171, 210, 95, 139, 120, 78, 45, 104, 38, 21, 239, 53, 90, 160, 190, 215, 33, 28, 3, 196, 118, 174, 15, 172, 103, 236, 92, 141, 251, 133, 235, 66, 40, 24, 38, 51, 167, 193, 102, 141, 249, 158, 12, 102, 23, 112, 238, 128, 230, 95, 202, 208, 236, 80, 161, 82, 50, 66, 192, 50, 12, 65, 24, 234, 191, 49, 69, 225, 51, 242, 129, 50, 100, 59, 68, 17, 43, 17, 166, 105, 210, 198, 170, 144, 233, 57, 34, 4, 10, 6, 126, 191, 163, 101, 195, 51, 97, 155, 45, 121, 19, 105, 11, 105, 44, 182, 190, 204, 206, 63, 43, 222, 186, 62 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Field",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Program",
                table: "Researchs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 79, 249, 99, 132, 117, 11, 24, 78, 90, 207, 83, 101, 248, 193, 104, 126, 216, 105, 190, 109, 94, 82, 133, 84, 10, 11, 17, 162, 106, 248, 81, 233, 132, 195, 89, 127, 208, 250, 203, 122, 81, 66, 6, 191, 111, 139, 85, 214, 42, 80, 136, 1, 185, 28, 223, 232, 126, 222, 67, 152, 57, 46, 87, 242 }, new byte[] { 187, 156, 236, 173, 211, 57, 19, 237, 49, 208, 100, 187, 3, 5, 243, 49, 154, 30, 221, 52, 96, 37, 32, 61, 209, 40, 64, 45, 254, 232, 134, 35, 232, 79, 127, 1, 113, 166, 82, 2, 162, 182, 155, 217, 142, 171, 193, 106, 121, 3, 173, 131, 136, 199, 210, 77, 207, 206, 206, 103, 105, 157, 112, 241, 248, 205, 169, 72, 36, 94, 152, 208, 34, 182, 59, 53, 1, 49, 100, 142, 1, 172, 12, 196, 109, 42, 88, 195, 170, 71, 90, 44, 78, 104, 169, 185, 152, 181, 72, 175, 67, 163, 108, 212, 130, 32, 84, 202, 32, 84, 207, 233, 192, 2, 243, 162, 77, 46, 223, 7, 234, 247, 88, 139, 97, 186, 145, 197 } });
        }
    }
}
