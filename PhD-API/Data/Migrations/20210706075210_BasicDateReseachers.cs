using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class BasicDateReseachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Researchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BachelorsResearchersNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Entity",
                table: "Researchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FullTimeEmployeesNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MastersResearchersNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartTimeEmployeesNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhDResearchersNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Researchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechniciansNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 144, 227, 199, 146, 119, 89, 134, 200, 75, 202, 216, 66, 106, 170, 194, 209, 165, 213, 209, 235, 88, 200, 161, 105, 229, 45, 117, 95, 224, 157, 193, 167, 186, 218, 156, 22, 213, 105, 92, 222, 60, 140, 254, 180, 126, 179, 136, 33, 64, 178, 221, 202, 180, 64, 12, 129, 52, 192, 117, 94, 151, 238, 190, 94 }, new byte[] { 35, 39, 137, 198, 153, 11, 18, 117, 185, 0, 27, 23, 205, 90, 22, 181, 29, 36, 89, 17, 212, 49, 240, 24, 0, 220, 105, 86, 127, 189, 79, 6, 84, 159, 11, 226, 82, 120, 57, 106, 65, 59, 8, 25, 12, 31, 116, 46, 210, 128, 43, 201, 227, 171, 253, 16, 19, 139, 255, 22, 114, 34, 152, 62, 212, 61, 135, 162, 100, 35, 64, 103, 155, 217, 179, 52, 230, 251, 236, 28, 155, 247, 47, 223, 126, 154, 29, 91, 155, 243, 200, 5, 104, 45, 46, 238, 143, 48, 198, 147, 147, 75, 244, 126, 230, 85, 60, 57, 88, 238, 52, 150, 108, 173, 213, 71, 118, 174, 25, 94, 236, 139, 12, 97, 159, 220, 233, 63 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "BachelorsResearchersNumber",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Entity",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "FullTimeEmployeesNumber",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "MastersResearchersNumber",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "PartTimeEmployeesNumber",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "PhDResearchersNumber",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "TechniciansNumber",
                table: "Researchs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 57, 73, 84, 207, 202, 64, 11, 62, 175, 33, 180, 123, 17, 93, 50, 176, 166, 202, 252, 185, 138, 153, 243, 187, 241, 240, 139, 145, 155, 119, 93, 31, 120, 105, 104, 124, 155, 92, 218, 83, 7, 226, 201, 223, 84, 213, 232, 38, 161, 54, 169, 121, 193, 254, 117, 135, 52, 84, 229, 66, 113, 214, 5, 30 }, new byte[] { 149, 125, 185, 199, 146, 105, 142, 138, 136, 12, 32, 176, 48, 140, 79, 2, 184, 118, 95, 135, 231, 25, 159, 81, 217, 249, 93, 32, 40, 198, 50, 81, 234, 4, 132, 21, 168, 97, 114, 91, 97, 245, 206, 10, 99, 140, 197, 52, 8, 199, 98, 210, 208, 22, 109, 44, 238, 109, 210, 246, 253, 0, 154, 209, 93, 101, 52, 79, 204, 17, 78, 201, 225, 6, 210, 182, 34, 171, 137, 115, 248, 112, 100, 238, 136, 101, 50, 209, 110, 103, 187, 46, 204, 191, 35, 147, 199, 79, 208, 168, 206, 164, 162, 204, 22, 228, 204, 244, 228, 27, 206, 94, 16, 198, 130, 124, 46, 128, 150, 81, 209, 91, 38, 64, 146, 243, 90, 133 } });
        }
    }
}
