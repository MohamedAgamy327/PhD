using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ResearcherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Researchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsRandomPassword = table.Column<bool>(type: "bit", nullable: false),
                    SearchStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researchers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Admin@gmail.com", new byte[] { 151, 93, 142, 187, 111, 60, 200, 245, 215, 143, 1, 72, 154, 99, 155, 214, 48, 170, 174, 9, 233, 120, 84, 192, 58, 230, 120, 127, 184, 118, 168, 229, 63, 44, 108, 110, 233, 79, 169, 234, 139, 217, 120, 61, 81, 185, 65, 194, 29, 77, 101, 124, 152, 108, 57, 164, 36, 233, 161, 236, 205, 20, 196, 84 }, new byte[] { 190, 201, 228, 174, 253, 8, 156, 202, 24, 254, 96, 187, 228, 52, 147, 193, 23, 53, 134, 7, 77, 135, 182, 36, 84, 190, 213, 227, 200, 179, 200, 72, 103, 161, 67, 77, 240, 250, 63, 104, 42, 64, 160, 99, 210, 230, 109, 170, 185, 83, 254, 201, 228, 101, 230, 11, 25, 7, 186, 252, 36, 11, 43, 21, 82, 201, 0, 112, 84, 105, 112, 54, 62, 42, 209, 118, 139, 184, 9, 98, 155, 10, 133, 227, 236, 144, 81, 124, 140, 24, 136, 72, 27, 109, 40, 114, 26, 23, 136, 81, 95, 27, 143, 200, 147, 45, 91, 207, 38, 112, 207, 74, 165, 36, 209, 29, 65, 60, 41, 239, 66, 229, 5, 15, 147, 112, 151, 219 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Researchers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 82, 139, 184, 19, 25, 98, 194, 174, 242, 67, 140, 131, 217, 113, 199, 22, 21, 170, 248, 77, 20, 58, 207, 193, 89, 239, 227, 91, 180, 93, 106, 142, 122, 178, 19, 136, 140, 56, 113, 173, 192, 183, 12, 220, 179, 47, 73, 154, 179, 97, 67, 110, 63, 107, 158, 252, 172, 147, 35, 18, 253, 76, 80, 143 }, new byte[] { 13, 205, 75, 12, 47, 207, 171, 47, 114, 241, 116, 85, 36, 19, 242, 45, 255, 181, 200, 123, 134, 233, 166, 118, 82, 4, 103, 240, 62, 237, 152, 255, 143, 95, 140, 162, 238, 41, 97, 216, 47, 49, 177, 193, 148, 173, 253, 156, 63, 43, 60, 211, 244, 32, 10, 226, 97, 4, 115, 72, 251, 233, 89, 57, 170, 82, 236, 62, 216, 59, 90, 233, 44, 12, 2, 94, 17, 65, 103, 163, 123, 235, 54, 131, 220, 118, 65, 179, 115, 199, 115, 212, 117, 35, 131, 188, 6, 51, 117, 78, 206, 48, 235, 130, 149, 23, 89, 137, 16, 255, 230, 244, 122, 200, 21, 140, 106, 73, 147, 6, 40, 35, 75, 222, 41, 6, 149, 54 } });
        }
    }
}
