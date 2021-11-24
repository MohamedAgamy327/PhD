﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UniversityTypeTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Researchs",
                newName: "UniversityType");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 203, 43, 104, 57, 165, 113, 83, 185, 136, 144, 249, 24, 217, 74, 163, 240, 148, 27, 86, 156, 65, 121, 3, 236, 125, 126, 152, 214, 55, 93, 212, 209, 198, 168, 97, 111, 222, 219, 30, 146, 10, 129, 34, 75, 30, 19, 220, 115, 102, 217, 207, 140, 203, 92, 65, 168, 146, 103, 166, 88, 140, 194, 64, 234 }, new byte[] { 110, 81, 228, 124, 173, 118, 136, 178, 225, 45, 133, 172, 168, 53, 211, 10, 53, 101, 96, 219, 98, 85, 165, 142, 99, 1, 133, 118, 183, 129, 162, 8, 10, 53, 76, 142, 252, 73, 52, 227, 211, 238, 205, 205, 23, 155, 107, 235, 75, 76, 59, 133, 223, 146, 71, 189, 142, 0, 197, 92, 154, 14, 106, 91, 245, 162, 49, 112, 34, 249, 70, 237, 123, 31, 33, 134, 47, 94, 5, 217, 70, 205, 29, 150, 94, 61, 77, 223, 68, 167, 210, 28, 122, 39, 166, 87, 13, 134, 40, 42, 49, 174, 4, 23, 176, 161, 169, 3, 71, 23, 23, 191, 125, 21, 57, 234, 98, 57, 254, 175, 149, 166, 140, 42, 144, 161, 181, 238 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniversityType",
                table: "Researchs",
                newName: "Type");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 86, 12, 97, 80, 100, 68, 184, 178, 51, 177, 135, 39, 167, 254, 246, 58, 163, 177, 158, 63, 139, 220, 80, 195, 188, 245, 96, 35, 40, 212, 199, 4, 157, 22, 115, 196, 120, 73, 110, 103, 232, 202, 137, 170, 35, 200, 118, 141, 184, 172, 205, 53, 118, 176, 77, 187, 181, 42, 99, 169, 68, 211, 196 }, new byte[] { 113, 22, 110, 254, 197, 172, 98, 149, 240, 81, 7, 120, 199, 204, 68, 91, 243, 167, 156, 64, 175, 85, 210, 73, 162, 113, 35, 130, 60, 207, 93, 74, 219, 245, 20, 118, 94, 156, 0, 105, 84, 89, 12, 128, 78, 61, 110, 174, 120, 238, 237, 48, 24, 137, 94, 220, 100, 69, 213, 168, 186, 10, 142, 91, 5, 205, 197, 248, 206, 138, 247, 184, 209, 166, 75, 130, 238, 39, 19, 74, 169, 24, 227, 195, 12, 97, 35, 39, 232, 138, 91, 75, 25, 180, 12, 128, 30, 87, 163, 237, 43, 179, 79, 250, 192, 76, 130, 39, 220, 121, 44, 196, 33, 81, 39, 209, 71, 60, 122, 229, 22, 159, 32, 148, 213, 142, 98, 240 } });
        }
    }
}