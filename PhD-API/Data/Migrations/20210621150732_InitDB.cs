using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsRandomPassword = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Researchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Researchs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsRandomPassword", "Name", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { 1, "Admin@gmail.com", true, "Admin", new byte[] { 62, 247, 12, 79, 102, 129, 58, 195, 91, 12, 78, 136, 249, 73, 203, 34, 219, 224, 92, 126, 85, 43, 5, 52, 68, 233, 82, 79, 162, 143, 118, 65, 212, 13, 46, 119, 159, 220, 214, 153, 255, 59, 136, 123, 130, 204, 116, 137, 240, 178, 190, 131, 130, 20, 92, 169, 82, 26, 174, 224, 120, 251, 22, 7 }, new byte[] { 34, 58, 40, 95, 64, 37, 69, 91, 49, 21, 158, 47, 127, 104, 112, 219, 160, 159, 75, 75, 221, 94, 213, 142, 58, 1, 79, 217, 85, 218, 6, 230, 126, 240, 167, 100, 19, 58, 139, 243, 51, 228, 233, 110, 192, 249, 8, 92, 186, 96, 252, 71, 49, 165, 132, 125, 2, 28, 84, 122, 81, 147, 155, 64, 240, 100, 173, 136, 34, 143, 70, 163, 73, 94, 103, 255, 225, 128, 80, 238, 217, 155, 173, 207, 108, 26, 216, 215, 38, 155, 211, 64, 106, 5, 212, 72, 35, 36, 31, 51, 229, 142, 157, 243, 17, 153, 15, 211, 171, 241, 86, 252, 208, 92, 240, 78, 172, 209, 75, 110, 1, 85, 245, 235, 135, 174, 176, 92 }, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Researchs_UserId",
                table: "Researchs",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Researchs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
