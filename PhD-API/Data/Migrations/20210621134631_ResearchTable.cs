using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ResearchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Researchers");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 143, 127, 73, 39, 103, 38, 241, 137, 222, 176, 68, 15, 253, 170, 6, 86, 92, 53, 168, 59, 21, 55, 128, 254, 218, 197, 205, 141, 171, 91, 31, 169, 31, 8, 61, 214, 14, 218, 17, 74, 98, 236, 46, 66, 68, 236, 73, 221, 8, 119, 82, 125, 39, 8, 204, 150, 109, 84, 204, 200, 104, 78, 232, 83 }, new byte[] { 55, 12, 229, 249, 176, 137, 204, 177, 147, 111, 151, 199, 125, 28, 175, 92, 149, 152, 126, 60, 162, 33, 210, 80, 224, 6, 246, 178, 153, 165, 75, 42, 231, 143, 158, 188, 215, 208, 216, 206, 62, 170, 81, 49, 20, 154, 106, 192, 94, 210, 81, 147, 161, 190, 185, 33, 174, 39, 216, 174, 197, 13, 105, 89, 129, 100, 59, 36, 78, 251, 180, 145, 80, 239, 44, 68, 84, 82, 251, 49, 32, 239, 231, 48, 4, 12, 187, 111, 126, 52, 0, 128, 206, 26, 57, 84, 133, 252, 107, 57, 11, 222, 100, 121, 136, 78, 187, 33, 246, 19, 147, 172, 214, 73, 232, 212, 71, 77, 95, 86, 164, 85, 180, 98, 108, 239, 38, 235 } });

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

            migrationBuilder.CreateTable(
                name: "Researchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRandomPassword = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 93, 142, 187, 111, 60, 200, 245, 215, 143, 1, 72, 154, 99, 155, 214, 48, 170, 174, 9, 233, 120, 84, 192, 58, 230, 120, 127, 184, 118, 168, 229, 63, 44, 108, 110, 233, 79, 169, 234, 139, 217, 120, 61, 81, 185, 65, 194, 29, 77, 101, 124, 152, 108, 57, 164, 36, 233, 161, 236, 205, 20, 196, 84 }, new byte[] { 190, 201, 228, 174, 253, 8, 156, 202, 24, 254, 96, 187, 228, 52, 147, 193, 23, 53, 134, 7, 77, 135, 182, 36, 84, 190, 213, 227, 200, 179, 200, 72, 103, 161, 67, 77, 240, 250, 63, 104, 42, 64, 160, 99, 210, 230, 109, 170, 185, 83, 254, 201, 228, 101, 230, 11, 25, 7, 186, 252, 36, 11, 43, 21, 82, 201, 0, 112, 84, 105, 112, 54, 62, 42, 209, 118, 139, 184, 9, 98, 155, 10, 133, 227, 236, 144, 81, 124, 140, 24, 136, 72, 27, 109, 40, 114, 26, 23, 136, 81, 95, 27, 143, 200, 147, 45, 91, 207, 38, 112, 207, 74, 165, 36, 209, 29, 65, 60, 41, 239, 66, 229, 5, 15, 147, 112, 151, 219 } });
        }
    }
}
