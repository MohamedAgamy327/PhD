using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ResearchUpdatesDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TechniciansNumber",
                table: "Researchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PhDResearchersNumber",
                table: "Researchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PartTimeEmployeesNumber",
                table: "Researchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MastersResearchersNumber",
                table: "Researchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FullTimeEmployeesNumber",
                table: "Researchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BachelorsResearchersNumber",
                table: "Researchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 253, 74, 170, 8, 199, 147, 50, 177, 39, 227, 166, 26, 92, 228, 75, 91, 33, 96, 30, 76, 46, 201, 209, 213, 81, 125, 116, 226, 34, 51, 238, 73, 86, 138, 82, 89, 5, 60, 162, 14, 98, 131, 206, 170, 213, 90, 243, 84, 32, 245, 233, 95, 200, 112, 37, 111, 172, 79, 247, 228, 241, 113, 109, 33 }, new byte[] { 40, 248, 93, 107, 58, 95, 153, 113, 127, 213, 159, 144, 105, 203, 99, 183, 206, 149, 167, 12, 67, 10, 221, 204, 56, 189, 13, 129, 144, 203, 160, 188, 199, 253, 184, 227, 128, 117, 8, 217, 121, 118, 58, 76, 119, 117, 148, 8, 112, 235, 183, 48, 189, 157, 24, 223, 244, 155, 91, 248, 18, 30, 48, 63, 253, 248, 41, 83, 193, 54, 206, 15, 152, 167, 189, 198, 13, 18, 33, 141, 35, 149, 199, 170, 241, 2, 20, 240, 171, 96, 226, 106, 20, 133, 41, 159, 146, 239, 250, 0, 139, 167, 77, 67, 182, 135, 213, 146, 242, 41, 174, 65, 4, 174, 206, 18, 66, 62, 112, 42, 53, 195, 101, 82, 245, 229, 57, 249 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TechniciansNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhDResearchersNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartTimeEmployeesNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MastersResearchersNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FullTimeEmployeesNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BachelorsResearchersNumber",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 158, 194, 177, 64, 165, 75, 80, 8, 88, 89, 13, 64, 137, 24, 114, 246, 230, 52, 173, 206, 72, 122, 193, 227, 162, 91, 82, 59, 169, 183, 114, 85, 239, 178, 163, 84, 161, 60, 166, 25, 44, 187, 9, 138, 150, 192, 15, 179, 114, 248, 135, 213, 71, 147, 88, 203, 6, 43, 76, 3, 11, 99, 73, 15 }, new byte[] { 32, 0, 196, 232, 5, 232, 216, 160, 142, 204, 125, 209, 204, 255, 171, 210, 95, 139, 120, 78, 45, 104, 38, 21, 239, 53, 90, 160, 190, 215, 33, 28, 3, 196, 118, 174, 15, 172, 103, 236, 92, 141, 251, 133, 235, 66, 40, 24, 38, 51, 167, 193, 102, 141, 249, 158, 12, 102, 23, 112, 238, 128, 230, 95, 202, 208, 236, 80, 161, 82, 50, 66, 192, 50, 12, 65, 24, 234, 191, 49, 69, 225, 51, 242, 129, 50, 100, 59, 68, 17, 43, 17, 166, 105, 210, 198, 170, 144, 233, 57, 34, 4, 10, 6, 126, 191, 163, 101, 195, 51, 97, 155, 45, 121, 19, 105, 11, 105, 44, 182, 190, 204, 206, 63, 43, 222, 186, 62 } });
        }
    }
}
