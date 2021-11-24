using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FirstONETwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FirstOne",
                table: "Researchs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FirstTwo",
                table: "Researchs",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 191, 62, 246, 15, 246, 83, 192, 5, 118, 190, 117, 136, 40, 131, 202, 5, 157, 147, 74, 57, 54, 13, 49, 232, 166, 189, 8, 54, 131, 72, 52, 251, 18, 173, 169, 134, 92, 144, 150, 161, 165, 56, 7, 33, 103, 42, 206, 88, 205, 96, 16, 160, 90, 69, 242, 103, 241, 24, 97, 116, 100, 55, 90, 222 }, new byte[] { 95, 172, 188, 107, 11, 80, 31, 110, 38, 134, 27, 94, 200, 170, 7, 153, 134, 171, 192, 118, 14, 86, 151, 48, 192, 87, 202, 227, 186, 183, 17, 69, 255, 102, 213, 110, 204, 171, 194, 59, 33, 223, 253, 186, 144, 132, 84, 132, 182, 144, 118, 13, 167, 183, 16, 106, 137, 151, 73, 146, 76, 13, 101, 94, 7, 226, 64, 70, 176, 194, 75, 81, 195, 91, 47, 101, 16, 122, 35, 29, 154, 84, 23, 88, 23, 37, 51, 9, 17, 148, 121, 101, 146, 210, 123, 253, 229, 164, 163, 174, 63, 179, 249, 28, 227, 101, 83, 64, 143, 145, 115, 161, 248, 170, 122, 91, 138, 67, 104, 10, 235, 244, 23, 38, 111, 188, 122, 231 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstOne",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "FirstTwo",
                table: "Researchs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 144, 0, 34, 227, 174, 196, 154, 71, 241, 227, 101, 206, 217, 89, 192, 193, 235, 69, 69, 89, 218, 83, 202, 238, 6, 28, 165, 248, 144, 58, 33, 7, 23, 235, 40, 46, 212, 84, 48, 225, 87, 148, 28, 226, 160, 135, 174, 227, 253, 32, 100, 253, 40, 163, 114, 40, 74, 120, 31, 55, 54, 252, 212, 61 }, new byte[] { 27, 75, 51, 192, 142, 19, 67, 20, 185, 135, 77, 210, 197, 184, 90, 215, 4, 0, 55, 169, 133, 31, 172, 53, 8, 149, 183, 130, 64, 126, 191, 121, 128, 222, 235, 141, 112, 126, 150, 45, 213, 61, 54, 11, 194, 85, 123, 50, 253, 200, 168, 196, 124, 10, 54, 60, 53, 67, 137, 77, 251, 212, 153, 89, 13, 113, 254, 238, 156, 132, 88, 7, 4, 222, 208, 184, 149, 189, 89, 8, 243, 22, 202, 121, 25, 109, 235, 114, 217, 109, 200, 199, 95, 4, 155, 90, 192, 70, 15, 34, 162, 149, 82, 15, 141, 12, 20, 178, 187, 83, 48, 117, 222, 110, 74, 228, 216, 56, 18, 48, 170, 73, 35, 75, 137, 218, 212, 148 } });
        }
    }
}
