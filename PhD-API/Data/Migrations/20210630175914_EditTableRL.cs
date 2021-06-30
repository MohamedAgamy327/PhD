using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EditTableRL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researchs_Users_UserId",
                table: "Researchs");

            migrationBuilder.DropIndex(
                name: "IX_Researchs_UserId",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "SearchStatus",
                table: "Researchs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Researchs",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Researchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRandomPassword",
                table: "Researchs",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Researchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Researchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Researchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 57, 73, 84, 207, 202, 64, 11, 62, 175, 33, 180, 123, 17, 93, 50, 176, 166, 202, 252, 185, 138, 153, 243, 187, 241, 240, 139, 145, 155, 119, 93, 31, 120, 105, 104, 124, 155, 92, 218, 83, 7, 226, 201, 223, 84, 213, 232, 38, 161, 54, 169, 121, 193, 254, 117, 135, 52, 84, 229, 66, 113, 214, 5, 30 }, new byte[] { 149, 125, 185, 199, 146, 105, 142, 138, 136, 12, 32, 176, 48, 140, 79, 2, 184, 118, 95, 135, 231, 25, 159, 81, 217, 249, 93, 32, 40, 198, 50, 81, 234, 4, 132, 21, 168, 97, 114, 91, 97, 245, 206, 10, 99, 140, 197, 52, 8, 199, 98, 210, 208, 22, 109, 44, 238, 109, 210, 246, 253, 0, 154, 209, 93, 101, 52, 79, 204, 17, 78, 201, 225, 6, 210, 182, 34, 171, 137, 115, 248, 112, 100, 238, 136, 101, 50, 209, 110, 103, 187, 46, 204, 191, 35, 147, 199, 79, 208, 168, 206, 164, 162, 204, 22, 228, 204, 244, 228, 27, 206, 94, 16, 198, 130, 124, 46, 128, 150, 81, 209, 91, 38, 64, 146, 243, 90, 133 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "IsRandomPassword",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Researchs");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Researchs");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Researchs",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SearchStatus",
                table: "Researchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 62, 247, 12, 79, 102, 129, 58, 195, 91, 12, 78, 136, 249, 73, 203, 34, 219, 224, 92, 126, 85, 43, 5, 52, 68, 233, 82, 79, 162, 143, 118, 65, 212, 13, 46, 119, 159, 220, 214, 153, 255, 59, 136, 123, 130, 204, 116, 137, 240, 178, 190, 131, 130, 20, 92, 169, 82, 26, 174, 224, 120, 251, 22, 7 }, new byte[] { 34, 58, 40, 95, 64, 37, 69, 91, 49, 21, 158, 47, 127, 104, 112, 219, 160, 159, 75, 75, 221, 94, 213, 142, 58, 1, 79, 217, 85, 218, 6, 230, 126, 240, 167, 100, 19, 58, 139, 243, 51, 228, 233, 110, 192, 249, 8, 92, 186, 96, 252, 71, 49, 165, 132, 125, 2, 28, 84, 122, 81, 147, 155, 64, 240, 100, 173, 136, 34, 143, 70, 163, 73, 94, 103, 255, 225, 128, 80, 238, 217, 155, 173, 207, 108, 26, 216, 215, 38, 155, 211, 64, 106, 5, 212, 72, 35, 36, 31, 51, 229, 142, 157, 243, 17, 153, 15, 211, 171, 241, 86, 252, 208, 92, 240, 78, 172, 209, 75, 110, 1, 85, 245, 235, 135, 174, 176, 92 } });

            migrationBuilder.CreateIndex(
                name: "IX_Researchs_UserId",
                table: "Researchs",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Researchs_Users_UserId",
                table: "Researchs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
